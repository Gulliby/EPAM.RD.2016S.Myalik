using DAL.Entities.Interface;
using DAL.Repositories.Interface;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using BLL.Services;

namespace Configurator.Domain
{
    public class DomainAssemblyLoader : MarshalByRefObject
    {
        public object LoadFrom<U>(string fileName, Type type, IRepository<U> userRepository, params IPEndPoint[] connections) 
            where U : IDalEntity
        {
            var assembly = Assembly.LoadFrom(fileName);
            var types = assembly.GetTypes();
            var instanceType = types.FirstOrDefault(element => element.Name == type.Name);
            if (instanceType == null)
                throw new ArgumentException(nameof(fileName));
            var instance = type == typeof(SlaveService) ? Activator.CreateInstance(instanceType, userRepository, connections[0]) : Activator.CreateInstance(instanceType, userRepository, connections);
            return instance;
        }
    }
}
