// <copyright file="ConnectionCollection.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ConnectionConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a custom configuration element containing a collection of child elements.
    /// </summary>
    public class ConnectionCollection : ConfigurationElementCollection
    {
        public ConnectionElement this[int idx] => (ConnectionElement)BaseGet(idx);

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (ConnectionElement)element;
        }
    }
}
