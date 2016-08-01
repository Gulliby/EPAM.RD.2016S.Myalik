using System;
using BLL.Entities.Interface;

namespace BLL.Event
{
    public class DataChangedEventArgs<TEntity>: EventArgs 
        where TEntity : IBllEnitity  
    {
        #region Private Fields

        #endregion

        #region Propetries

        public TEntity User { get; }

        #endregion

        #region Constructors

        public DataChangedEventArgs(TEntity user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            User = user;
        }

        #endregion
    }
}
