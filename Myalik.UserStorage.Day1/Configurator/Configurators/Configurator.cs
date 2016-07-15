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
    public class Configurator : IConfigurator
    {
        public void Config(out MasterService masterService, out IList<SlaveService> slaveServices)
        {
            var userRepository = new UserMemoryRepository();
            var userValidator = new UserValidator();
            masterService = new MasterService(userRepository, userValidator);
            slaveServices = new List<SlaveService>();
            for (var i = 0; i < 10; i++)
            {
                var slaveService = new SlaveService((IUserRepository) userRepository.Clone());
                masterService.OnDataChange += slaveService.DataChanged;
                slaveServices.Add(slaveService);
            }
        }
    }
}
