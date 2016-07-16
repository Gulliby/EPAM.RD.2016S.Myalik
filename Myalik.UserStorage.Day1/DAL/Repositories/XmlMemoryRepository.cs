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
    public class XmlMemoryRepository<TEntity>: IXmlMemoryRepository<TEntity> 
        where TEntity: IDalEntity
    {

        #region Fields

        protected IList<TEntity> entities;

        private readonly string xmlFileName;

        private IEnumerator<int> generator;

        #endregion

        #region Properties

        public IEnumerable<TEntity> Entities => entities;

        #endregion

        #region Constructors

        public XmlMemoryRepository()
        {
            entities = new List<TEntity>();
            generator = new IdGenerator().Generate().GetEnumerator();
        }

        public XmlMemoryRepository(IGenerator generator) : this()
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));
            this.generator = generator.Generate().GetEnumerator();
            xmlFileName = "repository.xml";
        }

        public XmlMemoryRepository(IGenerator generator, string xmlFileName) : this(generator)
        {
            if (string.IsNullOrEmpty(xmlFileName))
                throw new ArgumentNullException(nameof(xmlFileName));
            this.xmlFileName = xmlFileName;

        }

        #endregion

        #region Public Methods Repository Interface

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

        #endregion

        #region Public Methods XmlRepository Interface

        public void SaveToXml()
        {
            var sContainer = new SerializableContainer<TEntity>
            {
                Users = entities,
                Generator = generator
            };
            var formatter = new XmlSerializer(typeof(SerializableContainer<TEntity>));
            using (var fs = new FileStream(xmlFileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, sContainer);
            }
        }

        public void LoadFromXml()
        {
            var formatter = new XmlSerializer(typeof(IUserRepository));
            using (var fs = new FileStream(xmlFileName, FileMode.OpenOrCreate))
            {     
                var sContainer = (SerializableContainer<TEntity>)formatter.Deserialize(fs);
                entities = sContainer.Users;
                generator = sContainer.Generator;
            }
        }

        #endregion

        #region Clonable

        public object Clone()
        {
            return new XmlMemoryRepository<TEntity>(){
        }

        #endregion

    }
}
