// <copyright file="MainServerProxy.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace ServiceProxy.Proxies
{
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Entities;
    using BLL.Services;
    using BLL.Services.Interface;

    /// <summary>
    /// Custom proxy.
    /// </summary>
    public class MainServerProxy : IService<BllUser>
    {
        /// <summary>
        /// Service instance.
        /// </summary>
        private readonly IService<BllUser> master;

        /// <summary>
        /// Collection of service instance.
        /// </summary>
        private readonly List<IService<BllUser>> slaves;

        /// <summary>
        /// Current slave instance.
        /// </summary>
        private volatile int currentSlave;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainServerProxy"/> class.
        /// </summary>
        /// <param name="master">Master service.</param>
        /// <param name="slaves">Collection of slave services.</param>
        public MainServerProxy(IService<BllUser> master, IEnumerable<IService<BllUser>> slaves)
        {
            this.master = master;
            this.slaves = slaves.ToList();
        }

        /// <summary>
        /// Add an entity to service.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        public int AddEntity(BllUser entity)
        {
            return this.master.AddEntity(entity);
        }

        /// <summary>
        /// Delete and entity from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        public void DeleteEntity(int id)
        {
            this.master.DeleteEntity(id);
        }

        /// <summary>
        /// Method searches for users by name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByName(string name)
        {
            return this.GetSearchable().SearchEntityByName(name).ToList();
        }

        /// <summary>
        /// Method searches for users by last name. 
        /// </summary>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            return this.GetSearchable().SearchEntityByLastName(lastName).ToList();
        }

        /// <summary>
        /// Method searches for users by name and last name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            return this.GetSearchable().SearchEntityByNameAndLastName(name, lastName).ToList();
        }

        /// <summary>
        /// Method return all users from collection.
        /// </summary>
        /// <returns>All users from collection.</returns>
        public IEnumerable<BllUser> GetAll()
        {
            return this.GetSearchable().GetAll().ToList();
        }

        /// <summary>
        /// Commit service state.
        /// </summary>
        public void Commit()
        {
            ((MasterService)this.master).Commit();
        }

        /// <summary>
        /// Distributes duties between services.
        /// </summary>
        /// <returns>Free service.</returns>
        private IService<BllUser> GetSearchable()
        {
            if (this.slaves.Count <= 0)
            {
                return this.master;
            }

            var slave = this.currentSlave;
            this.currentSlave = (this.currentSlave + 1) % this.slaves.Count;
            return this.slaves[slave];
        }
    }
}
