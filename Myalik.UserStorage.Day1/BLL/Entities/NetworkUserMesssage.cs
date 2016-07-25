using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;
using DAL.Repositories.Interface;

namespace BLL.Entities
{
    [Serializable]
    public class NetworkUserMesssage : IMessage
    {
        public BllUser User { get; set; }

        public IUserRepository UserRepository { get; set; }

        public Function Function { get; set; }
    }
}
