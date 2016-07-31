using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL.Entities;
using ServiceProxy.Proxies;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class UserService : IUserService
    {
        private readonly MainServerProxy proxy;

        public UserService()
        {

        }

        public UserService(MainServerProxy proxy)
        {
            this.proxy = proxy;
        }

        public int Add(BllUser item)
        {
            return proxy.AddEntity(item);
        }

        public void Delete(int id)
        {
            proxy.DeleteEntity(id);
        }

        public IEnumerable<BllUser> GetAll()
        {
            return proxy.GetAll();
        }

        public IEnumerable<BllUser> SearchByName(string name)
        {
            return proxy.SearchEntityByName(name);
        }
    }
}
