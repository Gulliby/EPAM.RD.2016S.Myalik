using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Services;
using BLL.Services.Interface;

namespace ServiceProxy.Proxies
{
    public class MainServerProxy : IService<BllUser>
    {
        private readonly IService<BllUser> Master;
        private readonly List<IService<BllUser>> Slaves;
        private volatile int currentSlave;
        public MainServerProxy(IService<BllUser> master, IEnumerable<IService<BllUser>> slaves)
        {
            Master = master;
            Slaves = slaves.ToList();
        }

        public int AddEntity(BllUser entity)
        {
            return Master.AddEntity(entity);
        }

        public void DeleteEntity(int id)
        {
            Master.DeleteEntity(id);
        }  
     
        public IEnumerable<BllUser> SearchEntityByName(string name)
        {
            return GetSearchable().SearchEntityByName(name).ToList();
        }

        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            return GetSearchable().SearchEntityByLastName(lastName).ToList();
        }
       
        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            return GetSearchable().SearchEntityByNameAndLastName(name, lastName).ToList();
        }
        public IEnumerable<BllUser> GetAll()
        {
            return GetSearchable().GetAll().ToList();
        }
        private IService<BllUser> GetSearchable()
        {
            if (Slaves.Count <= 0)
                return Master;
            var slave = currentSlave;
            currentSlave = (currentSlave + 1) % Slaves.Count;
            return Slaves[slave];
        }
        public void Commit()
        {
            ((MasterService)Master).Commit();
        }
    }
}
