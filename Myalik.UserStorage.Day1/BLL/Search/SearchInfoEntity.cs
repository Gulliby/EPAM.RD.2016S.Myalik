// <copyright file="SearchInfoEntity.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Search
{
    using Entities;

    /// <summary>
    /// Entity store information of user which need to be found.
    /// </summary>
    public class SearchInfoEntity
    {
        /// <summary>
        /// Gets or sets name of user which need to be found.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last name of user which need to be found.
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets sex of user which need to be found.
        /// </summary>
        public BllGender Gender
        {
            get;
            set;
        }
    }
}
