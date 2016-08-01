using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using ServiceProxy.Proxies;

namespace WcfServiceLibrary.Configuration
{
    public class ServiceInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly MainServerProxy proxy;

        public ServiceInstanceProvider(MainServerProxy proxy)
        {
            if (proxy == null)
                throw new ArgumentNullException(nameof(proxy));
            this.proxy = proxy;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            disposable?.Dispose();
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return new UserService(proxy);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        #region Not Implemented

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion
    }
}
