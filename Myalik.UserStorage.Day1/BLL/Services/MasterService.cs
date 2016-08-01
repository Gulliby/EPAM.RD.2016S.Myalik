using BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using BLL.Entities;
using DAL.Repositories.Interface;
using BLL.Entities.Interface;
using BLL.Event;
using BLL.MainBllLogger;
using BLL.Validators.Interface;
using BLL.Validators;
using BLL.Mappers;
using BLL.Serializer;

namespace BLL.Services
{
    [Serializable]
    public class MasterService : UserSearchService, IService<BllUser>
    {
        
        private readonly IUserRepository userRepository;
        private readonly IValidator<BllUser> validator;
        private readonly IEnumerable<IPEndPoint> connectedServices;

        public MasterService(IUserRepository userRepository, IValidator<BllUser> validator) : base(userRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));
            this.userRepository = userRepository;
            this.validator = validator;
        }

        public MasterService(IUserRepository userRepository) : this(userRepository, new UserValidator()) { }


        public MasterService(IUserRepository userRepository, IEnumerable<IPEndPoint> connectedServices)
            : this(userRepository)
        {
           if (connectedServices == null)
                throw new ArgumentNullException(nameof(connectedServices));
            this.connectedServices = connectedServices;
        }

        public int AddEntity(BllUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (!validator.Validate(entity)) throw new ArgumentException(nameof(entity));
            int retId;
            try
            {
                slimLock.EnterWriteLock();
                retId = userRepository.Add(Mapper.ToDal(entity));
            }
            finally
            {
                slimLock.ExitWriteLock();
            }
            OnAdded(new DataChangedEventArgs<BllUser>(Mapper.ToBll(userRepository.SearchByPredicate(e => e.Id == retId))));
            if (retId == 0) return retId;
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("User with Name = {0} and LastName = {1} just added", entity.Name, entity.LastName);
            return retId;
        }

        public void DeleteEntity(int id)
        {
            var user = userRepository.SearchByPredicate(e => e.Id == id);
            if (user == null)
                throw new ArgumentException(nameof(id));
            try
            {
                slimLock.EnterWriteLock();
                userRepository.Delete(id);
            }
            finally
            {
                slimLock.ExitWriteLock();
            }          
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("User with Id = {0} just deleted", id);
            OnDeleted(new DataChangedEventArgs<BllUser>(Mapper.ToBll(user)));
        }

        private async void SendMessage(IMessage messsage)
        {
            foreach(var cs in connectedServices)
            {
                TcpClient client = null;
                try
                {
                    client = new TcpClient();
                    var data = MyBinarySerializer.Write(messsage);
                    await client.ConnectAsync(cs.Address, cs.Port);
                    using (var networkStream = client.GetStream())
                    {
                        await networkStream.WriteAsync(data, 0, data.Length);
                    }
                }
                finally
                {
                    client?.Close();
                }
            }
        }

        public void Commit()
        {
            userRepository.SaveToXml();
        }

        #region Event Functions

        protected virtual void OnDataChange(FullDataChangedEventArgs<IUserRepository> args)
        {
            SendMessage(new NetworkUserMesssage
            {
                UserRepository = args.Repository
            });
        }

        protected void OnAdded(DataChangedEventArgs<BllUser> args)
        {
            SendMessage(new NetworkUserMesssage
            {
                Function = Function.Add,
                User = args.User
            });
        }

        protected void OnDeleted(DataChangedEventArgs<BllUser> args)
        {
            SendMessage(new NetworkUserMesssage
            {
                Function = Function.Delete,
                User = args.User
            });
        }

        #endregion 
    }
}
