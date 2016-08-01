using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using ServiceProxy.Proxies;

namespace WcfServiceLibrary
{
    public class UserService : IUserService
    {
        private readonly MainServerProxy proxy;

        public UserService(){ }

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

        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            return proxy.SearchEntityByLastName(lastName);
        }

        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            return proxy.SearchEntityByNameAndLastName(name, lastName);
        }
    }
}
