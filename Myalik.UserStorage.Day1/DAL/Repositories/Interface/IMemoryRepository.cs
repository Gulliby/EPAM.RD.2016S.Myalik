using DAL.Entities.Interface;
using System.Collections.Generic;

namespace DAL.Repositories.Interface
{
    public interface IMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDalEntity
    {
        IEnumerable<TEntity> Entities { get; }
    }
}
