// <copyright file="ServiceConfigurator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Configurator.Configurators
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using BLL.Services;
    using Interface;
    using Domain;
    using DAL.Entities;
    using DAL.Entities.Interface;
    using DAL.Repositories;
    using DAL.Repositories.Interface;

    public class ServiceConfigurator : IConfigurator
    {
        /// <summary>
        /// Configure the services.
        /// </summary>
        /// <param name="countOfMasterServices">Count of master services</param>
        /// <param name="countOfSlaveServices">Count of slave services.</param>
        /// <param name="filePath">File path.</param>
        /// <param name="connections">Collection of connections to services.</param>
        /// <param name="masterService">Configured master service.</param>
        /// <param name="slaveServices">Configured slave services.</param>
        public void Config(int countOfMasterServices, int countOfSlaveServices, string filePath, IList<IPEndPoint> connections, out MasterService masterService, out IList<SlaveService> slaveServices)
        {
            if (countOfMasterServices > 1 && countOfMasterServices <= 0)
            {
                throw new ArgumentException(nameof(countOfMasterServices));
            }

            if (countOfSlaveServices <= 0)
            {
                throw new ArgumentException();
            }

            var userRepository = new UserXmlMemoryRepository(filePath);
            
            slaveServices = new List<SlaveService>();
            for (var i = 0; i < countOfSlaveServices; i++)
            {
                var slaveService = CreateService<SlaveService, DalUser>("SlaveDomain" + (i + 1), (UserXmlMemoryRepository)userRepository.Clone(), connections[i]);
                slaveServices.Add(slaveService);
            }

            masterService = CreateService<MasterService, DalUser>("MasterDomain", userRepository, connections.ToArray());
        }

        /// <summary>
        /// Creates the selected service.
        /// </summary>
        /// <typeparam name="T">Type of service.</typeparam>
        /// <typeparam name="U">Type of repository.</typeparam>
        /// <param name="domainName">Domain name instance.</param>
        /// <param name="repository">Repository instance.</param>
        /// <param name="connections">Collection of connections to services.</param>
        /// <returns>Created service.</returns>
        private T CreateService<T, U>(string domainName, IRepository<U> repository, params IPEndPoint[] connections) 
            where U : IDalEntity
        {
            var domain = AppDomain.CreateDomain(domainName);
            var loader = (DomainAssemblyLoader)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(DomainAssemblyLoader).FullName);
            return (T)loader.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bll.dll"), typeof(T), repository, connections);
        }

        /// <summary>
        /// Take the local address.
        /// </summary>
        /// <returns>Local address.</returns>
        private IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
            {
                return ip;
            }

            throw new Exception("Local IP Address Not Found!");
        }
    }
}
