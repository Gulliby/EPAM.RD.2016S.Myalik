// <copyright file="FileElement.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.FileConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a custom configuration element within a configuration file.
    /// </summary>
    public class FileElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets xml file path.
        /// </summary>
        [ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }
    }
}
