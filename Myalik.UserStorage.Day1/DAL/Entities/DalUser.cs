﻿using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Serializable]
    public class DalUser : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DalGender Gender { get; set; }

        public DateTime DayOfBirth { get; set; }

        public IList<DalVisaInfo> Visa { get; set; }

        public object Clone()
        {
            return new DalUser
            {
                DayOfBirth = DayOfBirth,
                Gender = Gender,
                Id = Id,
                Name = string.Copy(Name),
                LastName = string.Copy(LastName),
                Visa = Visa.Select(item => (DalVisaInfo)item.Clone()).ToList()
            };
        }
    }
}
