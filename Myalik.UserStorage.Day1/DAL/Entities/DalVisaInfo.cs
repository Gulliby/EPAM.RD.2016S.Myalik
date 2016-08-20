// <copyright file="DalVisaInfo.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Entities
{
    using Interface;
    using System;

    /// <summary>
    /// Entity witch store visa information.
    /// </summary>
    [Serializable]
    public struct DalVisaInfo : IDalEntity
    {
        /// <summary>
        /// Gets or sets uniquely identifies an object of country.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information of visa's country.
        /// </summary>
        public DalCountry Country
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about getting started.
        /// </summary>
        public DateTime Start
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about the end of the card works.
        /// </summary>
        public DateTime End
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current visa instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public object Clone()
        {
            return new DalVisaInfo
            {
                Country = (DalCountry)this.Country.Clone(),
                End = this.End,
                Id = this.Id,
                Start = this.Start
            };
        }
    }
}
