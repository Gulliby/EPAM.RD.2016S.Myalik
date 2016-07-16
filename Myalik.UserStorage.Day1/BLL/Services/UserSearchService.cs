using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Entities;
using BLL.MainBllLogger;
using BLL.Services.Interface;
using DAL.Entities;
using DAL.Repositories.Interface;

namespace BLL.Services
{
    public class UserSearchService : ISearchable<BllUser>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        
        public UserSearchService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DalUser, BllUser>();
            }).CreateMapper();
        }

        public IEnumerable<BllUser> SearchEntityByName(string name)
        {
            var entities = userRepository.SearchManyByPredicate(entity => entity.Name == name)
                .Select(mapper.Map<DalUser, BllUser>);
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}",name);
            return entities;
        }

        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            var entities = userRepository.SearchManyByPredicate(entity => entity.LastName == lastName)
                .Select(mapper.Map<DalUser, BllUser>);
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: lastName = {0}", lastName);
            return entities;
        }

        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            var entities = userRepository.SearchManyByPredicate(entity => (entity.LastName == lastName) && (entity.Name == name))
                .Select(mapper.Map<DalUser, BllUser>);
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}, lastName = {1}", name, lastName);
            return entities;
        }
    }
}
