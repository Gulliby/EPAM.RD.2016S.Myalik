// <copyright file="UserValidator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Validators
{
    using System;
    using Entities;
    using Interface;

    /// <summary>
    /// Custom validator.
    /// </summary>
    [Serializable] 
    public class UserValidator : IValidator<BllUser>
    {
        /// <summary>
        /// Validate user.
        /// </summary>
        /// <param name="entity">User instance to validate.</param>
        /// <returns> True if user instance is valid; otherwise - false.</returns>
        public bool Validate(BllUser entity)
        {
            return entity.Name != string.Empty;
        }
    }
}
