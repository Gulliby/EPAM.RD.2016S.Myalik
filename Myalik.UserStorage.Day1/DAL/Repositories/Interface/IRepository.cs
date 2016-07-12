using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IRepository<TEntity> 
        where TEntity : IEntity 
    {
        #region Interface Methods

        int Add(TEntity entity);

        IEnumerable<TEntity> SearchManyByPredicate(Expression<Func<TEntity,bool>> expression);

        TEntity SearchByPredicate(Expression<Func<TEntity,bool>> expression);

        void Delete(int id);

        #endregion
    }
}
