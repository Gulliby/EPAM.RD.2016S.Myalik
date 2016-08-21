// <copyright file="MemoryRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DAL.Entities.Interface;
    using DAL.Repositories.Interface;
    using Generator.Exceptions;
    using Generator.Generators;
    using Generator.Generators.Interface;

    /// <summary>
    /// Custom memory repository.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    [Serializable]
    public class MemoryRepository<TEntity> : IMemoryRepository<TEntity> 
        where TEntity : IDalEntity
    {
        #region Fields

        /// <summary>
        /// Collection of entities.
        /// </summary>
        protected IList<TEntity> entities;

        /// <summary>
        /// Generator instance.
        /// </summary>
        protected IGenerator generator;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryRepository{TEntity}"/> class.
        /// </summary>
        public MemoryRepository()
        {
            this.entities = new List<TEntity>();
            this.generator = new FibIdGenerator();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="generator">Generator instance.</param>
        public MemoryRepository(FibIdGenerator generator)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            this.generator = generator;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets entities which stores in repository.
        /// </summary>
        public IEnumerable<TEntity> Entities => this.entities;

        #endregion

        #region Public Methods Repository Interface

        /// <summary>
        /// Add an entity to repository.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        public int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!this.generator.MoveNext())
            {
                throw new IndexCantBeCreatedException();
            }

            entity.Id = this.generator.Current;
            this.entities.Add(entity);
            return entity.Id;
        }

        /// <summary>
        /// Delete and entity from repository.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        public void Delete(int id)
        {
            this.entities.Remove(this.entities.FirstOrDefault(entity => entity.Id == id));
        }

        /// <summary>
        /// Search an entity in repository by a predicate. 
        /// </summary>
        /// <param name="expression">Expression for searching.</param>
        /// <returns>Result of search. (first entity)</returns>
        public TEntity SearchByPredicate(Expression<Func<TEntity, bool>> expression)
        {
            return this.entities.AsQueryable().FirstOrDefault(expression);
        }

        /// <summary>
        /// Search entities in repository by a predicate. 
        /// </summary>
        /// <param name="expression">Expression for searching.</param>
        /// <returns>Result of search. (entities)</returns>
        public IEnumerable<TEntity> SearchManyByPredicate(Expression<Func<TEntity, bool>> expression)
        {
            return this.entities.AsQueryable().Where(expression);
        }

        #endregion

        #region Clonable

        /// <summary>
        /// Creates a new object that is a copy of the current memory repository instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public object Clone()
        {
            return new MemoryRepository<TEntity>
            {
                entities = this.entities.Select(item => (TEntity)item.Clone()).ToList(),
                generator = (IGenerator)this.generator.Clone(),
            };
        }

        #endregion
    }
}
