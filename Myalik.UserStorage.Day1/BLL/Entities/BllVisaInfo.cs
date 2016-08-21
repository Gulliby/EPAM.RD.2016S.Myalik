// <copyright file="BllVisaInfo.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities
{
    using System;
    using Interface;

    /// <summary>
    /// Entity witch store Visa information.
    /// </summary>
    [Serializable]
    public class BllVisaInfo : IBllEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BllVisaInfo"/> class.
        /// </summary>
        public BllVisaInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BllVisaInfo"/> class.
        /// </summary>
        /// <param name="id">Uniquely identifies an object of country.</param>
        public BllVisaInfo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }

        /// <summary>
        /// Gets uniquely identifies an object of country.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets information of visa's country.
        /// </summary>
        public BllCountry Country { get; set; }

        /// <summary>
        /// Gets or sets information about getting started.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets information about the end of the card works.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BllVisaInfo))
            {
                return false;
            }

            var item = (BllVisaInfo)obj;
            return this.Equals(item);
        }

        /// <summary>
        /// Custom hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Id ^ this.Country.GetHashCode()
                ^ this.Start.GetHashCode()
                ^ this.End.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object (visaInfo) is equal to the current object (visaInfo).
        /// </summary>
        /// <param name="visaInfo">The object (visaInfo) to compare with the current object (visaInfo).</param>
        /// <returns>true if the specified object (visaInfo) is equal to the current object (visaInfo); otherwise, false.</returns>
        private bool Equals(BllVisaInfo visaInfo)
        {
            return this.Country.Equals(visaInfo.Country)
                && this.Start.Equals(visaInfo.Start)
                && this.End.Equals(visaInfo.End);
        }
    }
}
