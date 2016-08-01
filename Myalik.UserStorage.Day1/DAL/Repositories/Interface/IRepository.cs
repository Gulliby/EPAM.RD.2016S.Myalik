using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Repositories.Interface
{
    public interface IRepository<TEntity> : ICloneable
        where TEntity : IDalEntity 
    {
        #region Interface Methods

        int Add(TEntity entity);

        IEnumerable<TEntity> SearchManyByPredicate(Expression<Func<TEntity,bool>> expression);

        TEntity SearchByPredicate(Expression<Func<TEntity,bool>> expression);

        void Delete(int id);

        #endregion
    }
}
