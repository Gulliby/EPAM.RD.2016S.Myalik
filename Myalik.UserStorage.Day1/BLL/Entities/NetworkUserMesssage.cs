using System;
using BLL.Entities.Interface;
using DAL.Repositories.Interface;

namespace BLL.Entities
{
    [Serializable]
    public struct NetworkUserMesssage : IMessage
    {
        public BllUser User { get; set; }

        public IUserRepository UserRepository { get; set; }

        public Function Function { get; set; }
    }
}
