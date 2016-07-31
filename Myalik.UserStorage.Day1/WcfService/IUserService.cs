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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        int Add(BllUser item);

        [OperationContract]
        IEnumerable<BllUser> SearchByName(string name);

        [OperationContract]
        IEnumerable<BllUser> GetAll();

        [OperationContract]
        void Delete(int id);
    }
}
