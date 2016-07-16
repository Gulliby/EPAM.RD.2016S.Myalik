using BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using BLL.Search;
using BLL.Entities;
using DAL.Repositories.Interface;
using DAL.Entities;
using AutoMapper;
using BLL.Entities.Interface;
using BLL.Event;
using BLL.MainBllLogger;
using BLL.Validators.Interface;

namespace BLL.Services
{
    public class MasterService : UserSearchService, IService<BllUser>, INotifyService
    {
        
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IValidator<BllUser> validator;
        public event EventHandler<DataEventArgs> OnDataChange = delegate { };
        
        public MasterService(IUserRepository userRepository, IValidator<BllUser> validator) : base(userRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            if (validator == null)
                throw new ArgumentNullException(nameof(validator));
            this.userRepository = userRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BllUser, DalUser>();
                cfg.CreateMap<DalUser, BllUser>();
            }).CreateMapper();
            this.validator = validator;
        }


        public int AddEntity(BllUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            if (!validator.Validate(entity)) throw new ArgumentException(nameof(entity));
            var retId = userRepository.Add(mapper.Map<BllUser, DalUser>(entity));
            if (retId == 0) return retId;
            Notify();
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("User with Name = {0} and LastName = {1} just added", entity.Name, entity.LastName);
            return retId;
        }

        public void DeleteEntity(int id)
        {
            userRepository.Delete(id);
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("User with Id = {0} just deleted", id);
            Notify();
        }

        public void Notify()
        {
            OnOnDataChange(new DataEventArgs((IUserRepository)userRepository.Clone()));
        }

        protected virtual void OnOnDataChange(DataEventArgs args)
        {
            OnDataChange(this, args);
        }

        public void Commit()
        {
            userRepository.SaveToXml();
        }
    }
}
