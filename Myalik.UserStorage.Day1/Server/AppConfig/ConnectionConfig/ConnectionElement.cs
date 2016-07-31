using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.ConnectionConfig
{
    public class ConnectionElement : ConfigurationElement
    {
        [ConfigurationProperty("address", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Address
        {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }

        [ConfigurationProperty("port", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Port
        {
            get { return (string)base["port"]; }
            set { base["port"] = value; }
        }
    }
}
