using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
