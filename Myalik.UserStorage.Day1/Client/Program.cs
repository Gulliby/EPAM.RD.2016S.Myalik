using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Services;
using Configurator.Configurators;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterService masterService;
            IList<SlaveService> slaveServices;
            var configurator = new ServiceConfigurator();
            configurator.Config(1, 4, "file.xml", out masterService, out slaveServices);
            masterService.AddEntity(new BllUser
            {
                DayOfBirth = DateTime.Now,
                Gender = BllGender.Female,
                LastName = "Ilya",
                Name = "Myalik",
                Visa = new List<BllVisaInfo>(),
            });
            masterService.Commit();
        }
    }
}
