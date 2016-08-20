// <copyright file="ServiceSectionConfig.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ServiceConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a section within a configuration file.
    /// </summary>
    public class ServiceSectionConfig : ConfigurationSection
    {
        /// <summary>
        /// Gets collection of the tag "Services".
        /// </summary>
        [ConfigurationProperty("Services")]
        public ServiceCollection ServiceItems => (ServiceCollection)base["Services"];
    }
}
