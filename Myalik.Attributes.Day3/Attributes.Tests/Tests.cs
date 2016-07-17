using System;
using System.Collections.Generic;
using System.Linq;
using Attributes.Collector;
using Attributes.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Attributes.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CreateEntityFromClass()
        {
            var users = new [] 
            {
                new User(1)
                {
                    FirstName = "Alexander",
                    LastName = "Alexandrov"
                },
                new User(2)
                {
                    FirstName = "Semen",
                    LastName = "Semenov"
                },
                new User(3)
                {
                    FirstName = "Petr",
                    LastName = "Petrov"
                }
            };
            var auc = new UserCollector();
            var result = auc.CreateEntityFromClass();
            CollectionAssert.AreEqual(result.ToArray(), users);
        }

        [TestMethod]
        public void CreateEntityFromAssembly()
        {
            var au = new AdvancedUser(4, 2329423)
            {
                FirstName = "Pavel",
                LastName = "Pavlov"
            };
            var auc = new AdvanceUserCollector();
            var result = auc.CreateEntityFromAssembly();
            Assert.AreEqual(result.ToArray()[0], au);
        }

        [TestMethod]
        public void ValidateEntity_IdMoreThanThousand_FalseReturned()
        {
            var user = new User(10000)
            {
                FirstName = "TestName",
                LastName = "TesmLastName"
            };
            var uc = new UserCollector();
            List<ValidationResult> results;
            var result = uc.ValidateEntity(user, out results);
            Assert.IsFalse(result);
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void ValidateEntity_IdLessThanOne_FalseReturned()
        {
            var user = new User(-1)
            {
                FirstName = "TestName",
                LastName = "TesmLastName"
            };
            var uc = new UserCollector();
            List<ValidationResult> results;
            var result = uc.ValidateEntity(user, out results);
            Assert.IsFalse(result);
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void ValidateEntity_TrueReturned()
        {
            var user = new User(1)
            {
                FirstName = "TestName",
                LastName = "TestLastName"
            };
            var uc = new UserCollector();
            List<ValidationResult> results;
            var result = uc.ValidateEntity(user, out results);
            Assert.IsTrue(result);
        }

    }
}
