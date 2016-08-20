// <copyright file="IUserRepository.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace DAL.Repositories.Interface
{
    using Entities;

    /// <summary>
    /// User repository interface.
    /// </summary>
    public interface IUserRepository : IMemoryRepository<DalUser>, IXmlRepository<DalUser>
    {
        /// <summary>
        /// Add visa to the user's visa collection.
        /// </summary>
        /// <param name="userId">User where visa need to be stored.</param>
        /// <param name="visaInfo">Information about a visa.</param>
        void AddVisaByUserId(int userId, DalVisaInfo visaInfo);

        /// <summary>
        /// Remove visa form the user's visa collection.
        /// </summary>
        /// <param name="userId">User where visa need to be deleted.</param>
        /// <param name="visaInfo">Information about a visa.</param>
        void RemoveVisaByUserId(int userId, DalVisaInfo visaInfo);
    }
}
