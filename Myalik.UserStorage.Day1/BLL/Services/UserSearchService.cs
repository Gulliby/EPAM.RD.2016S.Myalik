// <copyright file="UserSearchService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BLL.Entities;
    using BLL.MainBllLogger;
    using BLL.Mappers;
    using BLL.Services.Interface;
    using DAL.Repositories.Interface;

    /// <summary>
    /// Service for searching users.
    /// </summary>
    [Serializable]
    public class UserSearchService : MarshalByRefObject, ISearchable<BllUser>
    {
        /// <summary>
        /// ReaderWriterLockSlim instance.
        /// </summary>
        protected ReaderWriterLockSlim slimLock = new ReaderWriterLockSlim();

        /// <summary>
        /// User repository instance.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSearchService"/> class.
        /// </summary>
        /// <param name="userRepository">User repository instance.</param>
        public UserSearchService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Method searches for users by name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByName(string name)
        {
            IEnumerable<BllUser> entities;
            try
            {
                this.slimLock.EnterReadLock();
                entities = this.userRepository.SearchManyByPredicate(entity => entity.Name == name)
                .Select(Mapper.ToBll);
            }
            finally
            {
                this.slimLock.ExitReadLock();
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}", name);
            }

            return entities.ToList();
        }

        /// <summary>
        /// Method searches for users by last name. 
        /// </summary>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            IEnumerable<BllUser> entities;
            try
            {
                this.slimLock.EnterReadLock();
                entities = this.userRepository.SearchManyByPredicate(entity => entity.LastName == lastName)
                .Select(Mapper.ToBll);
            }
            finally
            {
                this.slimLock.ExitReadLock();
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("Processed search query with parameters: lastName = {0}", lastName);
            }

            return entities.ToList();
        }

        /// <summary>
        /// Method searches for users by name and last name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            IEnumerable<BllUser> entities;
            try
            {
                this.slimLock.EnterReadLock();
                entities = this.userRepository.SearchManyByPredicate(entity => (entity.LastName == lastName) && (entity.Name == name))
                .Select(Mapper.ToBll);
            }
            finally
            {
                this.slimLock.ExitReadLock();
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}, lastName = {1}", name, lastName);
            }

            return entities.ToList();
        }

        /// <summary>
        /// Method return all users from collection.
        /// </summary>
        /// <returns>All users from collection.</returns>
        public IEnumerable<BllUser> GetAll()
        {
            IEnumerable<BllUser> entities;
            try
            {
                this.slimLock.EnterReadLock();
                entities = this.userRepository.SearchManyByPredicate(entity => true)
                .Select(Mapper.ToBll).ToList();
            }
            finally
            {
                this.slimLock.ExitReadLock();
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("Get all processed.");
            }

            return entities.ToList();
        }
    }
}
