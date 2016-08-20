// <copyright file="ServiceCollection.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.AppConfig.ServiceConfig
{
    using System.Configuration;

    /// <summary>
    /// Represents a custom configuration element containing a collection of child elements.
    /// </summary>
    public class ServiceCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets a property or attribute of this configuration element.
        /// </summary>
        /// <param name="idx">index of the element.</param>
        /// <returns>Service element.</returns>
        public ServiceElement this[int idx] => (ServiceElement)BaseGet(idx);

        /// <summary>
        /// When overridden in a derived class, creates a new ConfigurationElement.
        /// </summary>
        /// <returns>A newly created ConfigurationElement.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The ConfigurationElement to return the key for.</param>
        /// <returns>An Object that acts as the key for the specified ConfigurationElement.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceElement)element).Type;
        }
    }
}
