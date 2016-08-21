// <copyright file="BllUser.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities
{ 
    using System;
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Entity witch store user information.
    /// </summary>
    [Serializable]
    public class BllUser : IBllEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BllUser"/> class.
        /// </summary>
        public BllUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BllUser"/> class.
        /// </summary>
        /// <param name="id">Uniquely identifies an object of country.</param>
        public BllUser(int id)
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
        public int Id
        {
            get;
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
        public BllGender Gender
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
        public List<BllVisaInfo> Visa
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var item = obj as BllUser;
            return item != null && this.Equals(item);
        }

        /// <summary>
        /// Custom hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Id ^ (this.Name.Length + (byte)this.Name[0])
                ^ (this.LastName.Length + (byte)this.LastName[0])
                ^ (int)this.Gender ^ this.PersonalId.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object (user) is equal to the current object (user).
        /// </summary>
        /// <param name="user">The object (user) to compare with the current object (user).</param>
        /// <returns>true if the specified object (user) is equal to the current object (user); otherwise, false.</returns>
        private bool Equals(BllUser user)
        {
            var visaFlag = true;
            if ((this.Visa != null) && (user.Visa != null))
            {
                visaFlag = new HashSet<BllVisaInfo>(this.Visa).SetEquals(new HashSet<BllVisaInfo>(user.Visa));
            }

            return (this.Name == user.Name)
                && (this.LastName == user.LastName)
                && (this.Gender == user.Gender)
                && this.DayOfBirth.Equals(user.DayOfBirth)
                && (this.PersonalId == user.PersonalId)
                && visaFlag;
        }
    }
}
