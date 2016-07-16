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
            if (retId != 0)
                Notify(); 
            return retId;
        }

        public void DeleteEntity(int id)
        {
            userRepository.Delete(id);
        }

        public void Notify()
        {
            OnOnDataChange(new DataEventArgs((IUserRepository)userRepository.Clone()));
        }

        protected virtual void OnOnDataChange(DataEventArgs args)
        {
            OnDataChange(this, args);
        }
    }
}
