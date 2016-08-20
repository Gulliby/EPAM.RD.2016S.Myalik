// <copyright file="ServiceInstanceProvider.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace WcfServiceLibrary.Configuration
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using ServiceProxy.Proxies;

    /// <summary>
    /// Declares methods that provide a service object or recycle a service object.
    /// </summary>
    public class ServiceInstanceProvider : IInstanceProvider, IContractBehavior
    {
        /// <summary>
        /// Main server proxy instance.
        /// </summary>
        private readonly MainServerProxy proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInstanceProvider"/> class.
        /// </summary>
        /// <param name="proxy">Main server proxy instance.</param>
        public ServiceInstanceProvider(MainServerProxy proxy)
        {
            if (proxy == null)
            {
                throw new ArgumentNullException(nameof(proxy));
            }

            this.proxy = proxy;
        }

        /// <summary>
        /// Called when an InstanceContext object recycles a service object.
        /// </summary>
        /// <param name="instanceContext">The service's instance context.</param>
        /// <param name="instance">The service object to be recycled.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            disposable?.Dispose();
        }

        /// <summary>
        /// Implements a modification or extension of the client across a contract.
        /// </summary>
        /// <param name="contractDescription">The contract description to be modified.</param>
        /// <param name="endpoint">The endpoint that exposes the contract.</param>
        /// <param name="dispatchRuntime">The dispatch runtime that controls service execution.</param>
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        /// <summary>
        /// Returns a service object given the specified InstanceContext object.
        /// </summary>
        /// <param name="instanceContext">The current InstanceContext object.</param>
        /// <returns>A user-defined service object.</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return new UserService(this.proxy);
        }

        /// <summary>
        /// Returns a service object given the specified InstanceContext object.
        /// </summary>
        /// <param name="instanceContext">The current InstanceContext object.</param>
        /// <param name="message">The message that triggered the creation of a service object.</param>
        /// <returns>The service object.</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        #region Not Implemented
        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="contractDescription">The parameter is not used.</param>
        /// <param name="endpoint">The parameter is not used.</param>
        /// <param name="bindingParameters">The parameter is not used..</param>
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="contractDescription">The parameter is not used.</param>
        /// <param name="endpoint">The parameter is not used.</param>
        /// <param name="clientRuntime">The parameter is not used.</param>
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="contractDescription">The parameter is not used.</param>
        /// <param name="endpoint">The parameter is not used.</param>
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion
    }
}
