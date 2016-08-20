// <copyright file="Function.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Entities
{
    using System;

    /// <summary>
    /// Enum witch is used to indicate a function.
    /// </summary>
    [Serializable]
    public enum Function
    {
        /// <summary>
        /// <para>
        ///  Add Function. It used to indicate that function "Add" was used.
        /// </para>
        /// </summary>
        Add,

        /// <summary>
        /// <para>
        ///  Delete Function. It used to indicate that function "Delete" was used.
        /// </para>
        /// </summary>
        Delete,

        /// <summary>
        /// <para>
        ///  ChangeAll Function. It used to indicate that function "ChangeAll" was used.
        /// </para>
        /// </summary>
        ChangeAll
    }
}
