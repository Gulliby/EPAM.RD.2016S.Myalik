using DAL.Entities.Interface;

namespace DAL.Repositories.Interface
{
    public interface IXmlRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDalEntity
    {
        void SaveToXml();
        void LoadFromXml();
    }
}
