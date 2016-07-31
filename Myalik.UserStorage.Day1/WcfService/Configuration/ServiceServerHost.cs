using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using ServiceProxy.Proxies;

namespace WcfService.Configuration
{
    public class ServiceServerHost : ServiceHost
    {
        public ServiceServerHost(MainServerProxy proxy, Type serviceType, params Uri[] baseAddresses)
        : base(serviceType, baseAddresses)
        {
            if (proxy == null)
                throw new ArgumentNullException(nameof(proxy));
            
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new ServiceInstanceProvider(proxy));
            }
        }
    }
}