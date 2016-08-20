// <copyright file="DalGender.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Entities
{
    using System;

    /// <summary>
    /// Entity witch store gender information.
    /// </summary>
    [Serializable]
    public enum DalGender
    {
        /// <summary>
        /// <para>
        ///  Male (men variable) with value 1
        /// </para>
        /// </summary>
        Male = 1,

        /// <summary>
        /// <para>
        ///  Female (women variable) with value 2
        /// </para>
        /// </summary>
        Female = 2
    }
}
