using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
