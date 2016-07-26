using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Xml.Serialization;
using DAL.Container;
using DAL.Entities.Interface;
using DAL.Repositories;
using Generator.Exceptions;
using Generator.Generators;
using Generator.Generators.Interface;

namespace DAL.Repositories
{
    [Serializable]
    public class MemoryRepository<TEntity>: IMemoryRepository<TEntity> 
        where TEntity: IDalEntity
    {

        #region Fields

        protected IList<TEntity> entities;

        protected IGenerator generator;

        #endregion

        #region Properties

        public IEnumerable<TEntity> Entities => entities;

        #endregion

        #region Constructors

        public MemoryRepository()
        {
            entities = new List<TEntity>();
            generator = new FibIterator();
        }

        public MemoryRepository(FibIterator generator) 
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            this.generator = generator;
        }

  
        #endregion

        #region Public Methods Repository Interface

        public int Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (!generator.MoveNext()) throw new IndexCantBeCreatedException();
            entity.Id = generator.Current;
            entities.Add(entity);
            return entity.Id;
        }

        public void Delete(int id)
        {
            entities.Remove(entities.FirstOrDefault(entity => entity.Id == id));
        }

        public TEntity SearchByPredicate(Expression<Func<TEntity, bool>> expression)
        {
            return entities.AsQueryable().FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> SearchManyByPredicate(Expression<Func<TEntity, bool>> expression)
        {
            return entities.AsQueryable().Where(expression);
        }

        #endregion

        #region Clonable

        public object Clone()
        {
            return new MemoryRepository<TEntity>
            {
                entities = entities.Select(item => (TEntity)item.Clone()).ToList(),
                generator = (IGenerator)generator.Clone(),
            };
        }

        #endregion

    }
}
