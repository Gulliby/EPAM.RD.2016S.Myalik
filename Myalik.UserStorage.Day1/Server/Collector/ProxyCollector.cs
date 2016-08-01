using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using BLL.Services;
using Configurator.Configurators;
using Server.AppConfig.ConnectionConfig;
using Server.AppConfig.FileConfig;
using Server.AppConfig.ServiceConfig;
using ServiceProxy.Proxies;

namespace Server.Collector
{
    public static class ProxyCollector
    {
        public static MainServerProxy GetConfigedServiceProxy()
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var fileSection = (FilePathConfig)cfg.GetSection("FilePaths");

            if (fileSection == null)
                throw new ArgumentNullException(nameof(fileSection));

            var serviceSection = (ServiceSectionConfig) cfg.GetSection("ServicesSection");

            if (serviceSection == null)
                throw new ArgumentNullException(nameof(serviceSection));

            var connectionSection = (ConnectionSectionConfig)cfg.GetSection("ConnectionsSection");

            if (connectionSection == null)
                throw new ArgumentNullException(nameof(connectionSection));

            var conf = new ServiceConfigurator();

            MasterService master;
            IList<SlaveService> slaves;
            conf.Config(GetMasterCount(serviceSection), GetSlaveCount(serviceSection), GetFilePath(fileSection), GetConnectionList(serviceSection,connectionSection), out master, out slaves);
            return new MainServerProxy(master,slaves);
        }

        private static string GetFilePath(FilePathConfig filePathConfig)
        {
            if(filePathConfig == null)
                throw new ArgumentNullException(nameof(filePathConfig));
            if((filePathConfig.FileItems.Count == 0) || (filePathConfig.FileItems.Count > 1))  
                throw new ArgumentException(nameof(filePathConfig));
            return filePathConfig.FileItems[0].Path;
        }

        private static List<IPEndPoint> GetConnectionList(ServiceSectionConfig serviceSectionConfig, ConnectionSectionConfig connectionSectionConfig)
        {
            var slaveCount = GetSlaveCount(serviceSectionConfig);
            var connectionCount = connectionSectionConfig.ConnectionElement.Count;
            if (slaveCount > connectionCount)
                throw new ArgumentException(nameof(serviceSectionConfig));
            var resultList = new List<IPEndPoint>();
            for (var i = 0; i < slaveCount; i++)
            {
                resultList.Add(new IPEndPoint(IPAddress.Parse(connectionSectionConfig.ConnectionElement[i].Address),
                    Convert.ToInt32(connectionSectionConfig.ConnectionElement[i].Port)));
            }
            return resultList;
        }

        private static int GetSlaveCount(ServiceSectionConfig serviceSectionConfig) => GetCount(serviceSectionConfig, "slave");

        private static int GetMasterCount(ServiceSectionConfig serviceSectionConfig) => GetCount(serviceSectionConfig, "master");

        private static int GetCount(ServiceSectionConfig serviceSectionConfig, string serviceName)
        {
            if (serviceSectionConfig == null)
                throw new ArgumentNullException(nameof(serviceSectionConfig));
            if (serviceName == null)
                throw new ArgumentNullException(nameof(serviceName));
            var count = 0;
            for (var i = 0; i < serviceSectionConfig.ServiceItems.Count; i++)
            {
                if (serviceSectionConfig.ServiceItems[i].Type != serviceName) continue;
                count = Convert.ToInt32(serviceSectionConfig.ServiceItems[i].Count);
                break;
            }
            return count;
        }
    }
}
