using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.AppConfig.FileConfig;

namespace Server.AppConfig.ServiceConfig
{
    public class ServiceSectionConfig : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public ServiceCollection ServiceItems => (ServiceCollection)base["Services"];
    }
}
