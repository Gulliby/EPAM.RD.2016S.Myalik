// <copyright file="IService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Services.Interface
{
    using Entities.Interface;

    /// <summary>
    /// Service interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface IService<TEntity> : ISearchable<TEntity>
        where TEntity : IBllEntity
    {
        /// <summary>
        /// Add an entity to service.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        int AddEntity(TEntity entity);

        /// <summary>
        /// Delete an entity from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        void DeleteEntity(int id);
    }
}
