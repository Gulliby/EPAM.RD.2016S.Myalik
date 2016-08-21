// <copyright file="FullDataChangedEventArgs.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Event
{
    using System;
    using DAL.Repositories.Interface;

    /// <summary>
    /// Custom event args.
    /// </summary>
    /// <typeparam name="TRepository">Custom repository.</typeparam>
    public class FullDataChangedEventArgs<TRepository> : EventArgs 
        where TRepository : IUserRepository
    {
        #region Private Fields

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FullDataChangedEventArgs{TRepository}"/> class.
        /// </summary>
        /// <param name="repository">Repository instance.</param>
        public FullDataChangedEventArgs(TRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.Repository = repository;
        }

        #endregion

        #region Propetries

        /// <summary>
        /// Gets repository that need to be cloned.
        /// </summary>
        public TRepository Repository
        {
            get;
        }

        #endregion
    }
}
