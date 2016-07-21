using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Event;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using BLL.MainBllLogger;

namespace BLL.Services
{
    [Serializable]
    public class SlaveService : UserSearchService, IService<BllUser>
    {
        private IUserRepository userRepository;

        public SlaveService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Created Slave Service" + AppDomain.CurrentDomain.FriendlyName);
        }

        public int AddEntity(BllUser entity)
        {
            throw new NotSupportedException();
        }

        public void DeleteEntity(int id)
        {
            throw new NotSupportedException();
        }

        public void DataChanged(object sender, DataEventArgs eventArgs)
        {
            userRepository = eventArgs.UserRepository;
        }
    }
}
