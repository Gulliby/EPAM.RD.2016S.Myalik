using System.Configuration;

namespace Server.AppConfig.FileConfig
{
    public class FileElement : ConfigurationElement
    {

        [ConfigurationProperty("path", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }
    }
}
