using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DalUnitTests
{
    [TestClass]
    public class DalTests
    {
        [TestMethod]
        public void MemoryRepositoryAdd_1_1Returned()
        {
            var memoryRepository = new MemoryRepository<DalUser>();
            var id = memoryRepository.Add(new DalUser
            {
                DayOfBirth = DateTime.Now,
                Gender = DalGender.Male,
                LastName = "Myalik",
                Name = "Ilya",
                Visa = new List<DalVisaInfo>()
            });
            Assert.AreEqual(1,id);
        }

        [TestMethod]
        public void MemoryRepository
    }
}
