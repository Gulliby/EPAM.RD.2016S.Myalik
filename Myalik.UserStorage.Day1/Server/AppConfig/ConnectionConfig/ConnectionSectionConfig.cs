// <copyright file="ConnectionSectionConfig.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ConnectionConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a section within a configuration file.
    /// </summary>
    public class ConnectionSectionConfig : ConfigurationSection
    {
        /// <summary>
        /// Gets collection of the tag "Connections".
        /// </summary>
        [ConfigurationProperty("Connections")]
        public ConnectionCollection ConnectionElement => (ConnectionCollection)base["Connections"];
    }
}
