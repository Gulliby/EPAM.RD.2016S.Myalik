// <copyright file="ServiceElement.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ServiceConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a custom configuration element within a configuration file.
    /// </summary>
    public class ServiceElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets type of service.
        /// </summary>
        [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        /// <summary>
        /// Gets or sets count of services.
        /// </summary>
        [ConfigurationProperty("count", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Count
        {
            get { return (string)base["count"]; }
            set { base["count"] = value; }
        }
    }
}
