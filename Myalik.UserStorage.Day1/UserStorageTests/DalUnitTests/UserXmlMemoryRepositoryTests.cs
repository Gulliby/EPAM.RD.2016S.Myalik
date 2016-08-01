using System.Collections.Generic;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserStorageTests.DalUnitTests
{
    [TestClass]
    public class UserXmlMemoryRepositoryTests
    {
        [TestMethod]
        public void UserMemoryRepository_AddVisa_NotEmptyList()
        {
            var userMemoryRepository = new UserXmlMemoryRepository("TestFile.xml");
            var user = new DalUser
            {
                Name = "TestName",
                LastName = "TestLastName",
                Visa = new List<DalVisaInfo>()
            };
            userMemoryRepository.Add(user);
            userMemoryRepository.AddVisaByUserId(1, new DalVisaInfo());
            Assert.AreEqual(1,user.Visa.Count);
        }

        [TestMethod]
        public void UserMemoryRepository_DeleteVisa_EmptyList()
        {
            var userMemoryRepository = new UserXmlMemoryRepository("TestFile.xml");
            var user = new DalUser
            {
                Name = "TestName",
                LastName = "TestLastName",
                Visa = new List<DalVisaInfo>()
            };
            userMemoryRepository.Add(user);
            userMemoryRepository.AddVisaByUserId(1, new DalVisaInfo());
            Assert.AreEqual(1, user.Visa.Count);
            userMemoryRepository.RemoveVisaByUserId(1,new DalVisaInfo());
            Assert.AreEqual(0, user.Visa.Count);
        }


    }
}
