// <copyright file="IDalEntity.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Entities.Interface
{
    using System;

    /// <summary>
    /// Dal entity interface.
    /// </summary>
    public interface IDalEntity : ICloneable
    {
        /// <summary>
        /// Gets or sets uniquely identifies an object of country.
        /// </summary>
        int Id
        {
            get;
            set;
        }       
    }
}
