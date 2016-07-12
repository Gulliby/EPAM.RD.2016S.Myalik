using DAL.Entities.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        IEnumerable<TEntity> Entities { get; }
    }
}
