using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;

namespace Configurator.Configurators.Interface
{
    public interface IConfigurator
    {
        void Config(int countOfMasterServices, int countOfSlaveServices, string filePath, out MasterService masterService, out IList<SlaveService> slaveServices);
    }
}
