using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Entities.Interface;
using DAL.Repositories;
using Generator.Exceptions;
using Generator.Generators;
using Generator.Generators.Interface;

namespace DAL.Repositories
{
    public class XmlMemoryRepository<TEntity>: IXmlMemoryRepository<TEntity> 
        where TEntity: IDalEntity
    {

        protected IList<TEntity> entities;

        private readonly IEnumerator<int> generator;

        public IEnumerable<TEntity> Entities => entities;

        public XmlMemoryRepository()
        {
            entities = new List<TEntity>();
            generator = new IdGenerator().Generate().GetEnumerator();
        }

        public XmlMemoryRepository(IGenerator generator) : this()
        {
            this.generator = generator.Generate().GetEnumerator();
        } 

        public int Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (!generator.MoveNext()) throw new IndexCantBeCreated();
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

        public void SaveToXml()
        {
            
        }

        public void LoadFromXml()
        {
            
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
