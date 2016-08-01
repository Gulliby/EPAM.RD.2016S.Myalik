using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    [Serializable]
    public class DalUser : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }

        public DalGender Gender { get; set; }

        public DateTime DayOfBirth { get; set; }

        public List<DalVisaInfo> Visa { get; set; }

        public object Clone()
        {
            return new DalUser
            {
                PersonalId = string.Copy(PersonalId),
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
