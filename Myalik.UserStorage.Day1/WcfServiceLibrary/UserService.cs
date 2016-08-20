// <copyright file="UserService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WcfServiceLibrary
{
    using System.Collections.Generic;
    using BLL.Entities;
    using ServiceProxy.Proxies;

    public class UserService : IUserService
    {
        /// <summary>
        /// Main server proxy instance.
        /// </summary>
        private readonly MainServerProxy proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
        {         
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="proxy">Main server proxy.</param>
        public UserService(MainServerProxy proxy)
        {
            this.proxy = proxy;
        }

        /// <summary>
        /// Add an user to service.
        /// </summary>
        /// <param name="item">User which need to be added.</param>
        /// <returns>Id of user.</returns>
        public int Add(BllUser item)
        {
            return this.proxy.AddEntity(item);
        }

        /// <summary>
        /// Delete an user from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        public void Delete(int id)
        {
            this.proxy.DeleteEntity(id);
        }

        /// <summary>
        /// Method return all users from collection.
        /// </summary>
        /// <returns>All users from collection.</returns>
        public IEnumerable<BllUser> GetAll()
        {
            return this.proxy.GetAll();
        }

        /// <summary>
        /// Method searches for users by name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchByName(string name)
        {
            return this.proxy.SearchEntityByName(name);
        }

        /// <summary>
        /// Method searches for users by last name. 
        /// </summary>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            return this.proxy.SearchEntityByLastName(lastName);
        }

        /// <summary>
        /// Method searches for users by name and last name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            return this.proxy.SearchEntityByNameAndLastName(name, lastName);
        }
    }
}
