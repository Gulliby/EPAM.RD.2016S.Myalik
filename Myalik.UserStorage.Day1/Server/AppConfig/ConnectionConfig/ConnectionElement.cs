// <copyright file="ConnectionElement.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ConnectionConfig
{
    using System.Configuration;

    public class ConnectionElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets client's address.
        /// </summary>
        [ConfigurationProperty("address", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Address
        {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }

        /// <summary>
        /// Gets or sets client's port.
        /// </summary>
        [ConfigurationProperty("port", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Port
        {
            get { return (string)base["port"]; }
            set { base["port"] = value; }
        }
    }
}
