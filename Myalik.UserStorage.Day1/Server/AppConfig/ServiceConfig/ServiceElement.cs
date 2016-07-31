using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.ServiceConfig
{
    public class ServiceElement : ConfigurationElement
    {
        [ConfigurationProperty("type", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("count", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Count
        {
            get { return (string)base["count"]; }
            set { base["count"] = value; }
        }
    }
}
