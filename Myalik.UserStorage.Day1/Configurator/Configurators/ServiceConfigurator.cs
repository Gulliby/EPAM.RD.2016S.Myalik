using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using BLL.Validators;
using Configurator.Configurators.Interface;
using DAL.Repositories;
using DAL.Repositories.Interface;
using System.IO; 
using System.Reflection; 
using System.Security.Policy; 


namespace Configurator.Configurators
{
    public class ServiceConfigurator : IConfigurator
    {
        public void Config(int countOfMasterServices, int countOfSlaveServices, string filePath,
            out MasterService masterService, out IList<SlaveService> slaveServices)
        {
            if (countOfMasterServices > 1 && countOfMasterServices <= 0)
                throw new ArgumentException(nameof(countOfMasterServices));
            if (countOfSlaveServices <= 0)
                throw new ArgumentException();

            var userRepository = new UserXmlMemoryRepository(filePath);
            var userValidator = new UserValidator();

            masterService = ConfigMaster(userRepository, userValidator);
            slaveServices = new List<SlaveService>();
            for (int i = 0; i < countOfSlaveServices; i++)
            {
                var slaveService = ConfigSlave((UserXmlMemoryRepository)userRepository.Clone(), i + 1);
                masterService.OnDataChange += slaveService.DataChanged;
                slaveServices.Add(slaveService);
            }
        }

        private SlaveService ConfigSlave(UserXmlMemoryRepository uxmr, int number)
        {
            var domain = AppDomain.CreateDomain("SlaveDomain" + number);
            var loader = (SlaveService)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, 
                typeof(SlaveService).FullName, new object[] { uxmr });
            return loader;
        }

        private MasterService ConfigMaster(UserXmlMemoryRepository uxmr, UserValidator validator)
        {
            var domain = AppDomain.CreateDomain("MasterService");
            var loader = (MasterService)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                typeof(MasterService).FullName, new object[] { uxmr , validator });
            return loader;
        }
    }
}
