// <copyright file="DalUser.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interface;  

    /// <summary>
    /// Custom user container.
    /// </summary>
    [Serializable]
    public class DalUser : IDalEntity
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
        /// Gets or sets user's name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user's last name.
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user's personal id.
        /// </summary>
        public string PersonalId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user's sex.
        /// </summary>
        public DalGender Gender
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user's birthday.
        /// </summary>
        public DateTime DayOfBirth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets collection of user's visa.
        /// </summary>
        public List<DalVisaInfo> Visa
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current user instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public object Clone()
        {
            return new DalUser
            {
                PersonalId = string.Copy(this.PersonalId),
                DayOfBirth = this.DayOfBirth,
                Gender = this.Gender,
                Id = this.Id,
                Name = string.Copy(this.Name),
                LastName = string.Copy(this.LastName),
                Visa = this.Visa.Select(item => (DalVisaInfo)item.Clone()).ToList()
            };
        }
    }
}
