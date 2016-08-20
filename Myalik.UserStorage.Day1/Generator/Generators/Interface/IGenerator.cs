// <copyright file="IGenerator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>

namespace Generator.Generators.Interface
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generator interface.
    /// </summary>
    public interface IGenerator : IEnumerator<int>, ICloneable
    {
        /// <summary>
        /// Gets information about previous number of the sequence.
        /// </summary>
        int Prev
        {
            get;
        }
    }
}
