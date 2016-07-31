using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AppConfig.ServiceConfig
{
    public class ServiceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceElement)element).Type;
        }

        public ServiceElement this[int idx] => (ServiceElement)BaseGet(idx);
    }
}
