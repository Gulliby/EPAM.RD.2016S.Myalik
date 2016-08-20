// <copyright file="FilePathConfig.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.FileConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a section within a configuration file.
    /// </summary>
    public class FilePathConfig : ConfigurationSection
    {
        /// <summary>
        /// Gets collection of the tag "Files".
        /// </summary>
        [ConfigurationProperty("Files")]
        public FilesCollection FileItems => (FilesCollection)base["Files"];
    }
}
