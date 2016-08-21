// <copyright file="IRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DAL.Entities.Interface;

    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface IRepository<TEntity> : ICloneable
        where TEntity : IDalEntity 
    {
        #region Interface Methods

        /// <summary>
        /// Add an entity to repository.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        int Add(TEntity entity);

        /// <summary>
        /// Search entities in repository by a predicate. 
        /// </summary>
        /// <param name="expression">Expression for searching.</param>
        /// <returns>Result of search. (entities)</returns>
        IEnumerable<TEntity> SearchManyByPredicate(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Search an entity in repository by a predicate. 
        /// </summary>
        /// <param name="expression">Expression for searching.</param>
        /// <returns>Result of search. (first entity)</returns>
        TEntity SearchByPredicate(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Delete and entity from repository.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        void Delete(int id);

        #endregion
    }
}
