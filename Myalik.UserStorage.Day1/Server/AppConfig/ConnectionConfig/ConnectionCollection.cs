using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.ConnectionConfig
{
    public class ConnectionCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (ConnectionElement)element;
        }

        public ConnectionElement this[int idx] => (ConnectionElement)BaseGet(idx);
    }
}
