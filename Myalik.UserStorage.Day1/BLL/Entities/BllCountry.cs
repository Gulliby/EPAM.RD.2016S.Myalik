// <copyright file="BllCountry.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities
{
    using System;
    using Interface;
    
    /// <summary>
    /// Entity witch store information about a country.
    /// </summary>
    [Serializable]
    public class BllCountry : IBllEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BllCountry"/> class.
        /// </summary>
        public BllCountry()
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BllCountry"/> class.
        /// </summary>
        /// <param name="id">Uniquely identifies an object of country.</param>
        public BllCountry(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }

        #region Properties

        /// <summary>
        /// Gets uniquely identifies an object of country.
        /// </summary>
        public int Id
        {
            get;
        }

        /// <summary>
        /// Gets or sets ISO.
        /// ISO = International Organization for Standardization. 
        /// </summary>
        public string ISO { get; set; }

        /// <summary>
        /// Gets or sets name of country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets country phone code.
        /// </summary>
        public int PhoneCode { get; set; }

        #endregion

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var item = obj as BllCountry;
            return item != null && this.Equals(item);
        }

        /// <summary>
        /// Custom hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Id ^ (this.ISO.Length + (byte)this.ISO[0])
                ^ (this.Name.Length + (byte)this.Name[0])
                ^ this.PhoneCode;
        }

        /// <summary>
        /// Determines whether the specified object (country) is equal to the current object (country).
        /// </summary>
        /// <param name="country">The object (country) to compare with the current object (country).</param>
        /// <returns>true if the specified object (country) is equal to the current object (country); otherwise, false.</returns>
        private bool Equals(BllCountry country)
        {
            return (this.ISO == country.ISO)
                && (this.Name == country.Name)
                && (this.PhoneCode == country.PhoneCode);
        }
    }
}
