// <copyright file="ProxyCollector.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server.Collector
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using BLL.Services;
    using Configurator.Configurators;
    using AppConfig.ConnectionConfig;
    using AppConfig.FileConfig;
    using AppConfig.ServiceConfig;
    using ServiceProxy.Proxies;

    public static class ProxyCollector
    {
        /// <summary>
        /// Configure all services using App.config.
        /// </summary>
        /// <returns>Main server proxy instance.</returns>
        public static MainServerProxy GetConfigedServiceProxy()
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var fileSection = (FilePathConfig)cfg.GetSection("FilePaths");

            if (fileSection == null)
            {
                throw new ArgumentNullException(nameof(fileSection));
            }

            var serviceSection = (ServiceSectionConfig)cfg.GetSection("ServicesSection");

            if (serviceSection == null)
            {
                throw new ArgumentNullException(nameof(serviceSection));
            }

            var connectionSection = (ConnectionSectionConfig)cfg.GetSection("ConnectionsSection");

            if (connectionSection == null)
            {
                throw new ArgumentNullException(nameof(connectionSection));
            }

            var conf = new ServiceConfigurator();

            MasterService master;
            IList<SlaveService> slaves;
            conf.Config(GetMasterCount(serviceSection), GetSlaveCount(serviceSection), GetFilePath(fileSection), GetConnectionList(serviceSection, connectionSection), out master, out slaves);
            return new MainServerProxy(master, slaves);
        }

        /// <summary>
        /// Getting xml file path.
        /// </summary>
        /// <param name="filePathConfig">File path configure.</param>
        /// <returns>File path.</returns>
        private static string GetFilePath(FilePathConfig filePathConfig)
        {
            if (filePathConfig == null)
            {
                throw new ArgumentNullException(nameof(filePathConfig));
            }

            if ((filePathConfig.FileItems.Count == 0) || (filePathConfig.FileItems.Count > 1))
            {
                throw new ArgumentException(nameof(filePathConfig));
            }

            return filePathConfig.FileItems[0].Path;
        }

        /// <summary>
        /// Getting all services connections.
        /// </summary>
        /// <param name="serviceSectionConfig">Service section configure.</param>
        /// <param name="connectionSectionConfig">Connection section configure.</param>
        /// <returns>Services connections.</returns>
        private static List<IPEndPoint> GetConnectionList(ServiceSectionConfig serviceSectionConfig, ConnectionSectionConfig connectionSectionConfig)
        {
            var slaveCount = GetSlaveCount(serviceSectionConfig);
            var connectionCount = connectionSectionConfig.ConnectionElement.Count;
            if (slaveCount > connectionCount)
            {
                throw new ArgumentException(nameof(serviceSectionConfig));
            }

            var resultList = new List<IPEndPoint>();
            for (var i = 0; i < slaveCount; i++)
            {
                resultList.Add(new IPEndPoint(IPAddress.Parse(connectionSectionConfig.ConnectionElement[i].Address), Convert.ToInt32(connectionSectionConfig.ConnectionElement[i].Port)));
            }

            return resultList;
        }

        /// <summary>
        /// Counts the number of slave services.
        /// </summary>
        /// <param name="serviceSectionConfig">Service section configure.</param>
        /// <returns>Number of slave services.</returns>
        private static int GetSlaveCount(ServiceSectionConfig serviceSectionConfig) => GetCount(serviceSectionConfig, "slave");

        /// <summary>
        /// Counts the number of master services.
        /// </summary>
        /// <param name="serviceSectionConfig">Service section configure.</param>
        /// <returns>Number of master services.</returns>
        private static int GetMasterCount(ServiceSectionConfig serviceSectionConfig) => GetCount(serviceSectionConfig, "master");

        /// <summary>
        /// Counts the number of services.
        /// </summary>
        /// <param name="serviceSectionConfig">Service section configure.</param>
        /// <param name="serviceName">Service name instance.</param>
        /// <returns>Number of services.</returns>
        private static int GetCount(ServiceSectionConfig serviceSectionConfig, string serviceName)
        {
            if (serviceSectionConfig == null)
            {
                throw new ArgumentNullException(nameof(serviceSectionConfig));
            }

            if (serviceName == null)
            {
                throw new ArgumentNullException(nameof(serviceName));
            }

            var count = 0;
            for (var i = 0; i < serviceSectionConfig.ServiceItems.Count; i++)
            {
                if (serviceSectionConfig.ServiceItems[i].Type != serviceName)
                {
                    continue;
                }

                count = Convert.ToInt32(serviceSectionConfig.ServiceItems[i].Count);
                break;
            }

            return count;
        }
    }
}
