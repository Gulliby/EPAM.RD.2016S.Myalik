using System.Configuration;

namespace Server.AppConfig.ServiceConfig
{
    public class ServiceSectionConfig : ConfigurationSection
    {
        [ConfigurationProperty("Services")]
        public ServiceCollection ServiceItems => (ServiceCollection)base["Services"];
    }
}
