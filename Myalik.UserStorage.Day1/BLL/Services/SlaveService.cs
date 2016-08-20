// <copyright file="SlaveService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Services
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Entities;
    using Entities.Interface;
    using Event;
    using Interface;
    using DAL.Repositories.Interface;
    using MainBllLogger;
    using Mappers;
    using Serializer;

    /// <summary>
    /// Provides functionality for working with users.
    /// </summary>
    [Serializable]
    public class SlaveService : UserSearchService, IService<BllUser>
    {
        /// <summary>
        /// Address End Point instance.
        /// </summary>
        private readonly IPEndPoint connection;

        /// <summary>
        /// User repository instance.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlaveService"/> class.
        /// </summary>
        /// <param name="userRepository">UserRepository instance.</param>
        public SlaveService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("Created Slave Service" + AppDomain.CurrentDomain.FriendlyName);
            }

            this.Listen();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlaveService"/> class.
        /// </summary>
        /// <param name="userRepository">UserRepository instance.</param>
        /// <param name="connection">Internet protocol address end point instance.</param>
        public SlaveService(IUserRepository userRepository, IPEndPoint connection) : this(userRepository)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            this.connection = connection;
        }

        /// <summary>
        /// Add an entity to service.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        public int AddEntity(BllUser entity)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Delete and entity from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        public void DeleteEntity(int id)
        {
            throw new NotSupportedException();
        }

        #region Event Functions

        /// <summary>
        /// Execution on receive add information.
        /// </summary>
        /// <param name="sender">Sender instance.</param>
        /// <param name="args">Arguments instance.</param>
        protected void OnAdded(object sender, DataChangedEventArgs<BllUser> args)
        {
            try
            {
                slimLock.EnterWriteLock();
                this.userRepository.Add(Mapper.ToDal(args.User));
            }
            finally
            {
                slimLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Execution on receive delete information.
        /// </summary>
        /// <param name="sender">Sender instance.</param>
        /// <param name="args">Arguments instance.</param>
        protected void OnDeleted(object sender, DataChangedEventArgs<BllUser> args)
        {
            try
            {
                slimLock.EnterWriteLock();
                this.userRepository.Delete(args.User.Id);
            }
            finally
            {
                slimLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Execution on receive all data change information.
        /// </summary>
        /// <param name="sender">Sender instance.</param>
        /// <param name="args">Arguments instance.</param>
        protected void OnDataChanged(object sender, FullDataChangedEventArgs<IUserRepository> args)
        {
            this.userRepository = args.Repository;
        }

        #endregion

        /// <summary>
        /// Listen to the information received
        /// </summary>
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

        /// <summary>
        /// Distributes duties between functions.
        /// </summary>
        /// <param name="message">Message instance.</param>
        private void Start(IMessage message)
        {
            var userMessage = (NetworkUserMesssage)message;
            switch (userMessage.Function)
            {
                case Function.Add:
                    {
                        this.OnAdded(new object(), new DataChangedEventArgs<BllUser>(userMessage.User));
                        break;
                    }

                case Function.Delete:
                    {
                        this.OnDeleted(new object(), new DataChangedEventArgs<BllUser>(userMessage.User));
                        break;
                    }

                case Function.ChangeAll:
                    {
                        this.OnDataChanged(new object(), new FullDataChangedEventArgs<IUserRepository>(userMessage.UserRepository));
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }
    }
}
