// <copyright file="ISearchable.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Services.Interface
{
    using System.Collections.Generic;
    using Entities.Interface;

    /// <summary>
    /// Searchable interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface ISearchable<out TEntity> 
        where TEntity : IBllEntity
    {
        /// <summary>
        /// Method searches for users by name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <returns>Founded users.</returns>
        IEnumerable<TEntity> SearchEntityByName(string name);

        /// <summary>
        /// Method searches for users by last name. 
        /// </summary>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        IEnumerable<TEntity> SearchEntityByLastName(string lastName);

        /// <summary>
        /// Method searches for users by name and last name. 
        /// </summary>
        /// <param name="name">Name of user.</param>
        /// <param name="lastName">Last name of user.</param>
        /// <returns>Founded users.</returns>
        IEnumerable<TEntity> SearchEntityByNameAndLastName(string name, string lastName);

        /// <summary>
        /// Method return all users from collection.
        /// </summary>
        /// <returns>All users from collection.</returns>
        IEnumerable<TEntity> GetAll();
    }
}
