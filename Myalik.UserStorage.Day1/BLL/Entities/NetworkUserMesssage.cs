// <copyright file="NetworkUserMesssage.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities
{
    using System;
    using DAL.Repositories.Interface;
    using Interface;

    /// <summary>
    /// Entity witch store message information.
    /// </summary>
    [Serializable]
    public struct NetworkUserMesssage : IMessage
    {
        /// <summary>
        /// Gets or sets information of a user that need to be added/deleted.
        /// </summary>
        public BllUser User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets repository that need to be cloned.
        /// </summary>
        public IUserRepository UserRepository
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets indicate of a function.
        /// </summary>
        public Function Function
        {
            get;
            set;
        }
    }
}
