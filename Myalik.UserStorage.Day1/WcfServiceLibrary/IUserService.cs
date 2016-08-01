using System.Collections.Generic;
using System.ServiceModel;
using BLL.Entities;

namespace WcfServiceLibrary
{
    
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        int Add(BllUser item);

        [OperationContract]
        IEnumerable<BllUser> SearchByName(string name);

        [OperationContract]
        IEnumerable<BllUser> SearchEntityByLastName(string lastName);

        [OperationContract]
        IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName);

        [OperationContract]
        IEnumerable<BllUser> GetAll();

        [OperationContract]
        void Delete(int id);
    }
}
