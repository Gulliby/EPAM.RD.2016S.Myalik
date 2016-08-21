// <copyright file="DomainAssemblyLoader.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Configurator.Domain
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using BLL.Services;
    using DAL.Entities.Interface;
    using DAL.Repositories.Interface;

    /// <summary>
    /// Custom domain assembly loader.
    /// </summary>
    public class DomainAssemblyLoader : MarshalByRefObject
    {
        /// <summary>
        /// Create instance of object of defined type from defined assembly
        /// </summary>
        /// <typeparam name="U">Type of object.</typeparam>
        /// <param name="fileName">File name instance.</param>
        /// <param name="type">Type instance.</param>
        /// <param name="userRepository">Repository instance.</param>
        /// <param name="connections">Collection of connections to services.</param>
        /// <returns>Created object.</returns>
        public object LoadFrom<U>(string fileName, Type type, IRepository<U> userRepository, params IPEndPoint[] connections) 
            where U : IDalEntity
        {
            var assembly = Assembly.LoadFrom(fileName);
            var types = assembly.GetTypes();
            var instanceType = types.FirstOrDefault(element => element.Name == type.Name);
            if (instanceType == null)
            {
                throw new ArgumentException(nameof(fileName));
            }

            var instance = type == typeof(SlaveService) ? Activator.CreateInstance(instanceType, userRepository, connections[0]) : Activator.CreateInstance(instanceType, userRepository, connections);
            return instance;
        }
    }
}
