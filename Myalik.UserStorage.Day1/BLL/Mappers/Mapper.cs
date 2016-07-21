using BLL.Entities;
using BLL.Entities.Interface;
using DAL.Entities;
using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mapper
    {
        
        #region ToDal

        public static IDalEntity ToDal(IBllEnitity bllEntity)
        {
            return ToDal((dynamic)bllEntity);
        }

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

        public static DalUser ToDal(BllUser user)
        {
            return new DalUser
            {
                Id = user.Id,
                DayOfBirth = user.DayOfBirth,
                Name = user.Name,
                LastName = user.LastName,
                Gender = (DalGender)user.Gender,
                Visa = user.Visa.Select(ToDal).ToList(),
            };
        }


        public static DalVisaInfo ToDal(BllVisaInfo visa)
        {
            return new DalVisaInfo
            {
                Id = visa.Id,
                Start = visa.Start,
                End =visa.End,
                Country = ToDal(visa.Country),
            };
        }

        #endregion

        #region ToBll

        public static IBllEnitity ToBll(IDalEntity dalEntity)
        {
            return ToDal((dynamic)dalEntity);
        }

        public static BllCountry ToBll(DalCountry country)
        {
            return new BllCountry
            {
                //Id = country.Id,
                ISO = country.ISO,
                Name = country.Name,
                PhoneCode = country.PhoneCode,
            };
        }

        public static BllUser ToBll(DalUser user)
        {
            return new BllUser
            {
                //Id = user.Id,
                DayOfBirth = user.DayOfBirth,
                Name = user.Name,
                LastName = user.LastName,
                Gender = (BllGender)user.Gender,
                Visa = user.Visa.Select(ToBll).ToList(),
            };
        }


        public static BllVisaInfo ToBll(DalVisaInfo visa)
        {
            return new BllVisaInfo
            {
                //Id = visa.Id,
                Start = visa.Start,
                End = visa.End,
                Country = ToBll(visa.Country),
            };
        }
        #endregion

    }

}