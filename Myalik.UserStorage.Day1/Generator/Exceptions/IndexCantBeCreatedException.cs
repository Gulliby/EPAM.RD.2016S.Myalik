// <copyright file="IndexCantBeCreatedException.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Generator.Exceptions
{
    using System;

    /// <summary>
    /// Custom exception when index can not be created.
    /// </summary>
    [Serializable]
    public class IndexCantBeCreatedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexCantBeCreatedException"/> class.
        /// </summary>
        public IndexCantBeCreatedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexCantBeCreatedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public IndexCantBeCreatedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexCantBeCreatedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception instance.</param>
        public IndexCantBeCreatedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
