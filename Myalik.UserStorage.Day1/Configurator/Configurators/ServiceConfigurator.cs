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
using Configurator.Domain;
using DAL.Entities.Interface;
using DAL.Entities;

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

            masterService = CreateService<MasterService, DalUser>("MasterDomain", userRepository);
            slaveServices = new List<SlaveService>();
            for (var i = 0; i < countOfSlaveServices; i++)
            {
                var slaveService = CreateService<SlaveService,DalUser>("SlaveDomain" + (i + 1),(UserXmlMemoryRepository)userRepository.Clone());
                //masterService.OnDataChange += slaveService.DataChanged;
                slaveServices.Add(slaveService);
            }
        }

        private T CreateService<T,U>(string domainName, IRepository<U> repository) 
            where U: IDalEntity
        {
            var domain = AppDomain.CreateDomain(domainName);
            var loader = (DomainAssemblyLoader)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName,
                typeof(DomainAssemblyLoader).FullName);
            return (T)loader.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bll.dll"),typeof(T), repository);
        }

    }
}
