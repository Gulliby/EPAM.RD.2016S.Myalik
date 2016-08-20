// <copyright file="IBllEntity.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities.Interface
{
    /// <summary>
    /// Interface for business logic layer entities.
    /// </summary>
    public interface IBllEntity
    {
        /// <summary>
        /// Gets uniquely identifies an object of country.
        /// </summary>
        int Id
        {
            get;
        }
    }
}
