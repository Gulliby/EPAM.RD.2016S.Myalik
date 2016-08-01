using System.Linq;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserStorageTests.BllUnitTests
{
    [TestClass]
    public class UserSearchServiceTests
    {
        [TestMethod]
        public void UserSearchService_SearchByName()
        {
            var userRepository = new UserXmlMemoryRepository("test.xml");
            var user = new DalUser
            {
                Name = "TestName"
            };
            userRepository.Add(user);
            var userSearchService = new UserSearchService(userRepository);
            var entities = userSearchService.SearchEntityByName(user.Name);
            Assert.AreEqual(1, entities.Count());
        }

        [TestMethod]
        public void UserSearchService_SearchByLastName()
        {
            var userRepository = new UserXmlMemoryRepository("test.xml");
            var user = new DalUser
            {
                LastName = "TestLastName"
            };
            userRepository.Add(user);
            var userSearchService = new UserSearchService(userRepository);
            var entities = userSearchService.SearchEntityByLastName(user.LastName);
            Assert.AreEqual(1, entities.Count());
        }

        [TestMethod]
        public void UserSearchService_SearchByNameAndLastName()
        {
            var userRepository = new UserXmlMemoryRepository("test.xml");
            var user = new DalUser
            {
                Name = "TestName",
                LastName = "TestLastName"
            };
            userRepository.Add(user);
            var userSearchService = new UserSearchService(userRepository);
            var entities = userSearchService.SearchEntityByNameAndLastName(user.Name, user.LastName);
            Assert.AreEqual(1, entities.Count());
        }
    }
}
