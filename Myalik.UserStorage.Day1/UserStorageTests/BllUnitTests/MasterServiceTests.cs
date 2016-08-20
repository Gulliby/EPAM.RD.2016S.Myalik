// <copyright file="MasterServiceTests.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace UserStorageTests.BllUnitTests
{
    using System;
    using BLL.Services;
    using BLL.Validators;
    using DAL.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MasterServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MasterService_UserRepositoryNull_ThrowsArgumentNullException()
        {
            new MasterService(null, new UserValidator());
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
