using BLL.Services.Interface;
using System;
using System.Collections.Generic;
using BLL.Search;
using BLL.Entities;
using DAL.Repositories.Interface;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    public class UserService : IService<BllUser>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            this.userRepository = userRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BllUser, DalUser>();
                cfg.CreateMap<DalUser, BllUser>();
            }).CreateMapper();

        }

        public int AddEntity(BllUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return userRepository.Add(mapper.Map<BllUser,DalUser>(entity));
        }

        public void DeleteEntity(int id)
        {
            userRepository.Delete(id);
        }

        public IEnumerable<BllUser> SearchEntitiesManyByPredicate(SearchInfoEntity searchInfoEntity)
        {
            userRepository.SearchManyByPredicate(entity =>
            (entity.Name == searchInfoEntity.Name)
            && (entity.LastName == searchInfoEntity.LastName)
            && ((int)entity.Gender == (int)searchInfoEntity.Gender)
            );
        }

        public BllUser SearchEntityByPredicate(SearchInfoEntity searchInfoEntity)
        {
            return mapper.Map<DalUser,BllUser>(userRepository.SearchByPredicate(entity =>
            (entity.Name == searchInfoEntity.Name)
            && (entity.LastName == searchInfoEntity.LastName)
            && ((int)entity.Gender == (int)searchInfoEntity.Gender)
            ));
        }
    }
}
