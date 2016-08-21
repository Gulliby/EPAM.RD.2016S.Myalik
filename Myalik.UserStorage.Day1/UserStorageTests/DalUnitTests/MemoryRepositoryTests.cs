// <copyright file="MemoryRepositoryTests.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace UserStorageTests.DalUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DAL.Entities;
    using DAL.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MemoryRepositoryTests
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
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void MemoryRepositoryDelete_EmptyList()
        {
            var memoryRepository = new MemoryRepository<DalUser>();
            var retId = memoryRepository.Add(new DalUser
            {
                Name = "TestName",
                LastName = "TestLastName"
            });
            Assert.AreEqual(1, memoryRepository.Entities.Count());
            memoryRepository.Delete(retId);
            Assert.AreEqual(0, memoryRepository.Entities.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MemoryRepository_GeneratorNull_ThrowsArgumentNullException()
        {
            new MemoryRepository<DalUser>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MemoryRepository_AddNullEntity_ThrowsArgumentNullException()
        {
            var memoryRepository = new MemoryRepository<DalUser>();
            memoryRepository.Add(null);
        }

        [TestMethod]
        public void MemoryRepository_SearchEntity_EntityReturned()
        {
            var memoryRepository = new MemoryRepository<DalUser>();
            var user = new DalUser
            {
                Name = "TestName",
                LastName = "TestLastName"
            };
            memoryRepository.Add(user);
            var entity = memoryRepository.SearchByPredicate(retUser =>
                retUser.Equals(user));
            Assert.IsNotNull(entity);
        }
    }
}
