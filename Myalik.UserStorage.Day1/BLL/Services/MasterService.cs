// <copyright file="MasterService.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using BLL.Entities;
    using BLL.Entities.Interface;
    using BLL.Event;
    using BLL.MainBllLogger;
    using BLL.Mappers;
    using BLL.Serializer;
    using BLL.Services.Interface;
    using BLL.Validators;
    using BLL.Validators.Interface; 
    using DAL.Repositories.Interface;

    /// <summary>
    /// Provides functionality for working with users.
    /// </summary>
    [Serializable]
    public class MasterService : UserSearchService, IService<BllUser>
    {
        /// <summary>
        /// User repository instance.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// User validator instance.
        /// </summary>
        private readonly IValidator<BllUser> validator;
        
        /// <summary>
        /// Collection of address end point instance.
        /// </summary>
        private readonly IEnumerable<IPEndPoint> connectedServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterService"/> class.
        /// </summary>
        /// <param name="userRepository">UserRepository instance.</param>
        /// <param name="validator">UserValidator instance.</param>
        public MasterService(IUserRepository userRepository, IValidator<BllUser> validator) : base(userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            this.userRepository = userRepository;
            this.validator = validator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterService"/> class.
        /// </summary>
        /// <param name="userRepository">UserRepository instance.</param>
        public MasterService(IUserRepository userRepository) : this(userRepository, new UserValidator())
        {    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterService"/> class.
        /// </summary>
        /// <param name="userRepository">UserRepository instance.</param>
        /// <param name="connectedServices">Collection of slave services.</param>
        public MasterService(IUserRepository userRepository, IEnumerable<IPEndPoint> connectedServices)
            : this(userRepository)
        {
            if (connectedServices == null)
            {
                throw new ArgumentNullException(nameof(connectedServices));
            }

            this.connectedServices = connectedServices;
        }

        /// <summary>
        /// Add an entity to service.
        /// </summary>
        /// <param name="entity">Entity which need to be added.</param>
        /// <returns>Id of entity.</returns>
        public int AddEntity(BllUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!this.validator.Validate(entity))
            {
                throw new ArgumentException(nameof(entity));
            }

            int retId;
            try
            {
                slimLock.EnterWriteLock();
                retId = this.userRepository.Add(Mapper.ToDal(entity));
            }
            finally
            {
                slimLock.ExitWriteLock();
            }

            this.OnAdded(new DataChangedEventArgs<BllUser>(Mapper.ToBll(this.userRepository.SearchByPredicate(e => e.Id == retId))));
            if (retId == 0)
            {
                return retId;
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("User with Name = {0} and LastName = {1} just added", entity.Name, entity.LastName);
            }

            return retId;
        }

        /// <summary>
        /// Delete and entity from service.
        /// </summary>
        /// <param name="id">Id which need to be deleted.</param>
        public void DeleteEntity(int id)
        {
            var user = this.userRepository.SearchByPredicate(e => e.Id == id);
            if (user == null)
            {
                throw new ArgumentException(nameof(id));
            }

            try
            {
                slimLock.EnterWriteLock();
                this.userRepository.Delete(id);
            }
            finally
            {
                slimLock.ExitWriteLock();
            }

            if (BllLogger.BooleanSwitch)
            {
                BllLogger.Instance.Info("User with Id = {0} just deleted", id);
            }

            this.OnDeleted(new DataChangedEventArgs<BllUser>(Mapper.ToBll(user)));
        } 

        /// <summary>
        /// Commit service state.
        /// </summary>
        public void Commit()
        {
            this.userRepository.SaveToXml();
        }

        #region Event Functions

        /// <summary>
        /// Execution after all information will change.
        /// </summary>
        /// <param name="args">Arguments instance.</param>
        protected virtual void OnDataChange(FullDataChangedEventArgs<IUserRepository> args)
        {
            this.SendMessage(new NetworkUserMesssage
            {
                UserRepository = args.Repository
            });
        }

        /// <summary>
        /// Execution after add new user.
        /// </summary>
        /// <param name="args">Arguments instance.</param>
        protected void OnAdded(DataChangedEventArgs<BllUser> args)
        {
            this.SendMessage(new NetworkUserMesssage
            {
                Function = Function.Add,
                User = args.User
            });
        }

        /// <summary>
        /// Execution after delete new user.
        /// </summary>
        /// <param name="args">Arguments instance.</param>
        protected void OnDeleted(DataChangedEventArgs<BllUser> args)
        {
            this.SendMessage(new NetworkUserMesssage
            {
                Function = Function.Delete,
                User = args.User
            });
        }

        #endregion 

        /// <summary>
        /// Method send message to slave services.
        /// </summary>
        /// <param name="messsage">Message which need to be sent.</param>
        private async void SendMessage(IMessage messsage)
        {
            foreach (var cs in this.connectedServices)
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
    }
}
