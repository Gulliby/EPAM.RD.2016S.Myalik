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

            masterService = new MasterService(userRepository, userValidator);
            slaveServices = new List<SlaveService>();

            for (var i = 0; i < countOfSlaveServices; i++)
            {
                var slaveService = new SlaveService((IUserRepository) userRepository.Clone());
                masterService.OnDataChange += slaveService.DataChanged;
                slaveServices.Add(slaveService);
            }
        }
    }
}
