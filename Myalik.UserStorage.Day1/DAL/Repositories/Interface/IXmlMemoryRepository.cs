using DAL.Entities.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IXmlMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDalEntity
    {
        IEnumerable<TEntity> Entities { get; }
        void SaveToXml();
        void LoadFromXml();
    }
}
