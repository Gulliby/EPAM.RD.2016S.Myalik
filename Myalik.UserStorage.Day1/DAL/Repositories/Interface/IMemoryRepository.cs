// <copyright file="IMemoryRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories.Interface
{
    using System.Collections.Generic;
    using Entities.Interface;

    /// <summary>
    /// Memory repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface IMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IDalEntity
    {
        /// <summary>
        /// Gets entities which stores in repository.
        /// </summary>
        IEnumerable<TEntity> Entities
        {
            get;
        }
    }
}
