using System;
using BLL.Services;
using BLL.Validators;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserStorageTests.BllUnitTests
{
    [TestClass]
    public class MasterServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MasterService_UserRepositoryNull_ThrowsArgumentNullException()
        {
            new MasterService(null,new UserValidator());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MasterService_AddNullEntity_ThrowsArgumentNullException()
        {
            var masterService = new MasterService(new UserXmlMemoryRepository("test.xml"), new UserValidator());
            masterService.AddEntity(null);
        }

    }
}
