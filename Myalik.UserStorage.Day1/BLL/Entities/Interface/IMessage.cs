// <copyright file="IMessage.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities.Interface
{
    /// <summary>
    /// Interface for Network Messages.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets or sets indicate of a function.
        /// </summary>
        Function Function
        {
            get;
            set;
        }
    }
}
