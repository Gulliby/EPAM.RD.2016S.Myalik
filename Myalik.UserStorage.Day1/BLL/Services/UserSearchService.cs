using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.MainBllLogger;
using BLL.Services.Interface;
using DAL.Entities;
using DAL.Repositories.Interface;
using BLL.Mappers;

namespace BLL.Services
{
    [Serializable]
    public class UserSearchService : MarshalByRefObject, ISearchable<BllUser>
    {
        private readonly IUserRepository userRepository;
        protected ReaderWriterLockSlim slimLock = new ReaderWriterLockSlim();
        public UserSearchService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<BllUser> SearchEntityByName(string name)
        {
            IEnumerable<BllUser> entities;
            try
            {
                slimLock.EnterReadLock();
                entities = userRepository.SearchManyByPredicate(entity => entity.Name == name)
                .Select(Mapper.ToBll);
            }
            finally
            {
                slimLock.ExitReadLock();
            }
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}",name);
            return entities;
        }

        public IEnumerable<BllUser> SearchEntityByLastName(string lastName)
        {
            IEnumerable<BllUser> entities;
            try
            {
                slimLock.EnterReadLock();
                entities = userRepository.SearchManyByPredicate(entity => entity.LastName == lastName)
                .Select(Mapper.ToBll);
            }
            finally
            {
                slimLock.ExitReadLock();
            }
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: lastName = {0}", lastName);
            return entities;
        }

        public IEnumerable<BllUser> SearchEntityByNameAndLastName(string name, string lastName)
        {
            IEnumerable<BllUser> entities;
            try
            {
                slimLock.EnterReadLock();
                entities = userRepository.SearchManyByPredicate(entity => (entity.LastName == lastName) && (entity.Name == name))
                .Select(Mapper.ToBll);
            }
            finally
            {
                slimLock.ExitReadLock();
            }
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Processed search query with parameters: name = {0}, lastName = {1}", name, lastName);
            return entities;
        }

        public IEnumerable<BllUser> GetAll()
        {
            IEnumerable<BllUser> entities;
            try
            {
                slimLock.EnterReadLock();
                entities = userRepository.SearchManyByPredicate(entity => true)
                .Select(Mapper.ToBll);
            }
            finally
            {
                slimLock.ExitReadLock();
            }
            if (BllLogger.BooleanSwitch)
                BllLogger.Instance.Info("Get all processed.");
            return entities;
        }
    }
}
