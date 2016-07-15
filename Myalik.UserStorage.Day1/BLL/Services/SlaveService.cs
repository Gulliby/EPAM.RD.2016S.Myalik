using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Event;
using BLL.Services.Interface;
using DAL.Repositories.Interface;

namespace BLL.Services
{
    public class SlaveService : UserSearchService, IService<BllUser>
    {
        private IUserRepository userRepository;

        public SlaveService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
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
