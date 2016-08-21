// <copyright file="DataChangedEventArgs.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Event
{
    using System;
    using Entities.Interface;

    /// <summary>
    /// Custom event args.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public class DataChangedEventArgs<TEntity> : EventArgs 
        where TEntity : IBllEntity  
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataChangedEventArgs{TEntity}"/> class.
        /// </summary>
        /// <param name="user">User instance.</param>
        public DataChangedEventArgs(TEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            this.User = user;
        }

        #endregion

        #region Propetries

        /// <summary>
        /// Gets information of a user that need to be added/deleted.
        /// </summary>
        public TEntity User
        {
            get;
        }

        #endregion
    }
}
