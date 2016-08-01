using System.Collections.Generic;
using System.Net;
using BLL.Services;

namespace Configurator.Configurators.Interface
{
    public interface IConfigurator
    {
        void Config(int countOfMasterServices, int countOfSlaveServices, string filePath, IList<IPEndPoint> connections ,out MasterService masterService, out IList<SlaveService> slaveServices);
    }
}
