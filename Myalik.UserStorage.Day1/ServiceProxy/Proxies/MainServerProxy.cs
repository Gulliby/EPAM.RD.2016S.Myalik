using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Slaves.Count <= 0)
                return Master.SearchEntityByName(name);
            var slave = currentSlave;
            currentSlave = (currentSlave + 1) % Slaves.Count;
            return Slaves[slave].SearchEntityByName(name).ToList();
        }

        public void Commit()
        {
            ((MasterService)Master).Commit();    
        }

        #region Not Emplemented

        public IEnumerable<BllUser> GetAll()
        {
            if (Slaves.Count <= 0)
                return Master.GetAll();
            var slave = currentSlave;
            currentSlave = (currentSlave + 1) % Slaves.Count;
            return Slaves[slave].GetAll().ToList();
        }

        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            throw new NotImplementedException();
        }
       
        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
