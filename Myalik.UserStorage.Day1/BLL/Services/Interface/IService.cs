using BLL.Entities.Interface;
using BLL.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IService<TEntity>
        where TEntity : IBllEnitity
    {
        int AddEntity(TEntity entity);

        IEnumerable<TEntity> SearchEntitiesManyByPredicate(SearchInfoEntity searchInfoEntity);

        TEntity SearchEntityByPredicate(SearchInfoEntity searchInfoEntity);

        void DeleteEntity(int id);
    }
}
