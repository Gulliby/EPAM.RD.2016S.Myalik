using DAL.Entities;
using DAL.Entities.Interface;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Domain
{
    public class DomainAssemblyLoader : MarshalByRefObject
    {
        public object LoadFrom<U>(string fileName, Type type, IRepository<U> userRepository) 
            where U : IDalEntity
        {
            var assembly = Assembly.LoadFrom(fileName);
            var types = assembly.GetTypes();
            var instanceType = types.FirstOrDefault(element => element.Name == type.Name);
            var instance = Activator.CreateInstance(instanceType, new object[] { userRepository });
            return instance;

        }
    }
}
