using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.FileConfig
{
    public class FilePathConfig : ConfigurationSection
    {
        [ConfigurationProperty("Files")]
        public FilesCollection FileItems => (FilesCollection)base["Files"];
    }
}
