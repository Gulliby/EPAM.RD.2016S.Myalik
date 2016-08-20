// <copyright file="DalCountry.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Entities
{
    using Interface;
    using System;

    [Serializable]
    public class DalCountry : IDalEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets uniquely identifies an object of country.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ISO.
        /// ISO = International Organization for Standardization. 
        /// </summary>
        public string ISO
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets name of country.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets country phone code.
        /// </summary>
        public int PhoneCode
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Creates a new object that is a copy of the current country instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public object Clone()
        {
            return new DalCountry
            {
                Id = this.Id,
                ISO = string.Copy(this.ISO),
                Name = string.Copy(this.Name),
                PhoneCode = this.PhoneCode
            };
        }
    }
}
