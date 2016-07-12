using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Entities.Interface;
using DAL.Repositories;

namespace DAL.Repositories
{
    public class MemoryRepository<TEntity>: IMemoryRepository<TEntity> 
        where TEntity: IEntity
    {

        protected IList<TEntity> entities;
        public IEnumerable<TEntity> Entities
        {
            get { return entities; }
        }

        public MemoryRepository()
        {
            entities = new List<TEntity>();
        }

        public int Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
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
    }
}
