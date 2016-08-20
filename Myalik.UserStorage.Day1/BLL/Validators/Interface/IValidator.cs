// <copyright file="IValidator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Validators.Interface
{
    using Entities.Interface;

    /// <summary>
    /// Validator interface.
    /// </summary>
    /// <typeparam name="TEntity">Custom entity.</typeparam>
    public interface IValidator<in TEntity> 
        where TEntity : IBllEntity
    {
        /// <summary>
        /// Validate entities.
        /// </summary>
        /// <param name="entity">Entity instance to validate.</param>
        /// <returns> True if entity instance is valid; otherwise - false.</returns>
        bool Validate(TEntity entity);
    }
}
