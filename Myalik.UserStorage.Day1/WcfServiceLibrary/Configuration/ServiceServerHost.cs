using System;
using System.ServiceModel;
using ServiceProxy.Proxies;

namespace WcfServiceLibrary.Configuration
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
