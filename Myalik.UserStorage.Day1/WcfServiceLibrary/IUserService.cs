// <copyright file="IUserService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WcfServiceLibrary
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using BLL.Entities;

    /// <summary>
    /// User service interface.
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// Add an user to service.
        /// </summary>
        /// <param name="item">User which need to be added.</param>
        /// <returns>Id of user.</returns>
        [OperationContract]
        int Add(BllUser item);

        /// <summary>
        /// Method searches for users by name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <returns>Founded users.</returns>
        [OperationContract]
        IEnumerable<BllUser> SearchByName(string name);

        /// <summary>
        /// Method searches for users by last name. 
        /// </summary>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        [OperationContract]
        IEnumerable<BllUser> SearchEntityByLastName(string lastName);

        /// <summary>
        /// Method searches for users by name and last name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        [OperationContract]
        IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName);

        /// <summary>
        /// Method return all users from collection.
        /// </summary>
        /// <returns>All users from collection.</returns>
        [OperationContract]
        IEnumerable<BllUser> GetAll();

        /// <summary>
        /// Delete an user from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        [OperationContract]
        void Delete(int id);
    }
}
