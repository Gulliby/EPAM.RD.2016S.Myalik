// <copyright file="ServiceServerHost.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WcfServiceLibrary.Configuration
{
    using System;
    using System.ServiceModel;
    using ServiceProxy.Proxies;

    /// <summary>
    /// Custom service host.
    /// </summary>
    public class ServiceServerHost : ServiceHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceServerHost"/> class.
        /// </summary>
        /// <param name="proxy">Main server proxy.</param>
        /// <param name="serviceType">Service type.</param>
        /// <param name="baseAddresses">Array of addresses.</param>
        public ServiceServerHost(MainServerProxy proxy, Type serviceType, params Uri[] baseAddresses)
        : base(serviceType, baseAddresses)
        {
            if (proxy == null)
            {
                throw new ArgumentNullException(nameof(proxy));
            }

            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new ServiceInstanceProvider(proxy));
            }
        }
    }
}
