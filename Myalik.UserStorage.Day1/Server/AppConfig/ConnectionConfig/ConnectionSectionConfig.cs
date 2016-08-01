using System.Configuration;

namespace Server.AppConfig.ConnectionConfig
{
    public class ConnectionSectionConfig : ConfigurationSection
    {
        [ConfigurationProperty("Connections")]
        public ConnectionCollection ConnectionElement => (ConnectionCollection)base["Connections"];
    }
}
