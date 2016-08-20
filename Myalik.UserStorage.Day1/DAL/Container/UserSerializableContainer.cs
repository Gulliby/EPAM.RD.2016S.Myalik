// <copyright file="UserSerializableContainer.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>

namespace DAL.Container
{
    using System.Collections.Generic;
    using Entities;

    public class UserSerializableContainer
    {
        /// <summary>
        /// Gets or sets information about current number of the sequence.
        /// </summary>
        public int Current
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets information about previous number of the sequence.
        /// </summary>
        public int Prev
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets serializable users.
        /// </summary>
        public List<DalUser> Users
        {
            get;
            set;
        } 
    }
}
