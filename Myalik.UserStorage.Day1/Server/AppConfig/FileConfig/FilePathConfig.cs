using System.Configuration;

namespace Server.AppConfig.FileConfig
{
    public class FilePathConfig : ConfigurationSection
    {
        [ConfigurationProperty("Files")]
        public FilesCollection FileItems => (FilesCollection)base["Files"];
    }
}
