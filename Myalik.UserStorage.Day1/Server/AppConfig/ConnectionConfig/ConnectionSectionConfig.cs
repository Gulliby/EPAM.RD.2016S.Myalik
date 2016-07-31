using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.ConnectionConfig
{
    public class ConnectionSectionConfig : ConfigurationSection
    {
        [ConfigurationProperty("Connections")]
        public ConnectionCollection ConnectionElement => (ConnectionCollection)base["Connections"];
    }
}
