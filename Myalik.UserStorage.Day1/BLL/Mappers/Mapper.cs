// <copyright file="Mapper.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Mappers
{
    using System.Linq;
    using DAL.Entities.Interface;
    using DAL.Entities;
    using Entities.Interface;
    using Entities;

    public static class Mapper
    {
        #region ToDal

        /// <summary>
        /// Method map data access layer entity to business logic layer entity.
        /// </summary>
        /// <param name="bllEntity">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static IDalEntity ToDal(IBllEntity bllEntity)
        {
            return ToDal((dynamic)bllEntity);
        }

        /// <summary>
        /// Method map data access layer country to business logic layer country.
        /// </summary>
        /// <param name="country">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static DalCountry ToDal(BllCountry country)
        {
            return new DalCountry
            {
                Id = country.Id,
                ISO = country.ISO,
                Name = country.Name,
                PhoneCode = country.PhoneCode,
            };
        }

        /// <summary>
        /// Method map data access layer user to business logic layer user.
        /// </summary>
        /// <param name="user">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static DalUser ToDal(BllUser user)
        {
            var visaInfos = user.Visa?.Select(ToDal).ToList();
            return new DalUser
            {
                Id = user.Id,
                PersonalId = user.PersonalId,
                DayOfBirth = user.DayOfBirth,
                Name = user.Name,
                LastName = user.LastName,
                Gender = (DalGender)user.Gender,
                Visa = visaInfos,
            };
        }

        /// <summary>
        /// Method map data access layer visa to business logic layer visa.
        /// </summary>
        /// <param name="visa">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static DalVisaInfo ToDal(BllVisaInfo visa)
        {
            return new DalVisaInfo
            {
                Id = visa.Id,
                Start = visa.Start,
                End = visa.End,
                Country = ToDal(visa.Country),
            };
        }

        #endregion

        #region ToBll

        /// <summary>
        /// Method map business logic layer entity to data access layer entity.
        /// </summary>
        /// <param name="dalEntity">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static IBllEntity ToBll(IDalEntity dalEntity)
        {
            return ToDal((dynamic)dalEntity);
        }

        /// <summary>
        /// Method map business logic layer country to data access layer country.
        /// </summary>
        /// <param name="country">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static BllCountry ToBll(DalCountry country)
        {
            return new BllCountry(country.Id)
            {
                ISO = country.ISO,
                Name = country.Name,
                PhoneCode = country.PhoneCode,
            };
        }

        /// <summary>
        /// Method map business logic layer user to data access layer user.
        /// </summary>
        /// <param name="user">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static BllUser ToBll(DalUser user)
        {
            var visaInfos = user.Visa?.Select(ToBll).ToList();
            return new BllUser(user.Id)
            {
                DayOfBirth = user.DayOfBirth,
                PersonalId = user.PersonalId,
                Name = user.Name,
                LastName = user.LastName,
                Gender = (BllGender)user.Gender,
                Visa = visaInfos,
            };
        }

        /// <summary>
        /// Method map business logic layer visa to data access layer visa.
        /// </summary>
        /// <param name="visa">Entity for mapping.</param>
        /// <returns>Mapped entity.</returns>
        public static BllVisaInfo ToBll(DalVisaInfo visa)
        {
            return new BllVisaInfo(visa.Id)
            {
                Start = visa.Start,
                End = visa.End,
                Country = ToBll(visa.Country),
            };
        }
        #endregion
    }
}