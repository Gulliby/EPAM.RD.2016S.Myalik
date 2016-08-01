using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BLL.Entities;
using BLL.Entities.Interface;
using BLL.Event;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using BLL.MainBllLogger;
using BLL.Mappers;
using BLL.Serializer;

namespace BLL.Services
{
    [Serializable]
    public class SlaveService : UserSearchService, IService<BllUser>
    {
        private IUserRepository userRepository;
        private readonly IPEndPoint connection;

        public SlaveService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Created Slave Service" + AppDomain.CurrentDomain.FriendlyName);
            Listen();
        }

        public SlaveService(IUserRepository userRepository, IPEndPoint connection) : this (userRepository)
        {
            if(connection == null)
                throw new ArgumentNullException(nameof(connection));
            this.connection = connection;
        }

        public int AddEntity(BllUser entity)
        {
            throw new NotSupportedException();
        }

        public void DeleteEntity(int id)
        {
            throw new NotSupportedException();
        }

        protected void Listen()
        {
            ThreadPool.QueueUserWorkItem(async e =>
            {
                TcpListener listener = null;
                try
                {
                    listener = new TcpListener(connection.Address, connection.Port);
                    listener.Start();
                    while (true)
                    {
                        TcpClient tcpClient = null;
                        try
                        {
                            tcpClient = await listener.AcceptTcpClientAsync();
                            var stream = tcpClient.GetStream();
                            var message = await MyBinarySerializer.ReadAsync<NetworkUserMesssage>(stream);
                            Start(message);
                        }
                        finally
                        {
                            tcpClient?.Close();
                        }
                    }
                }
                finally
                {
                    listener?.Stop();
                }
            });
        }

        private void Start(IMessage message)
        {
            var userMessage = (NetworkUserMesssage) message; 
            switch (userMessage.Function)
            {
                case Function.Add:
                {
                    OnAdded(new object(), new DataChangedEventArgs<BllUser>(userMessage.User));
                    break;
                }
                case Function.Delete:
                {
                    OnDeleted(new object(), new DataChangedEventArgs<BllUser>(userMessage.User));
                    break;
                }
                case Function.ChangeAll:
                {
                    OnDataChanged(new object(), new FullDataChangedEventArgs<IUserRepository>(userMessage.UserRepository));
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region Event Functions

        protected void OnAdded(object sender, DataChangedEventArgs<BllUser> args)
        {
            try
            {
                slimLock.EnterWriteLock();
                userRepository.Add(Mapper.ToDal(args.User));
            }
            finally
            {
                slimLock.ExitWriteLock();
            }

        }

        protected void OnDeleted(object sender, DataChangedEventArgs<BllUser> args)
        {
            try
            {
                slimLock.EnterWriteLock();
                userRepository.Delete(args.User.Id);
            }
            finally
            {
                slimLock.ExitWriteLock();
            }
        }

        protected void OnDataChanged(object sender, FullDataChangedEventArgs<IUserRepository> args)
        {
            userRepository = args.Repository;
        }

        #endregion

    }
}
