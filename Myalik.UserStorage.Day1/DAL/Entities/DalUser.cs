using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DalUser : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DalGender Gender { get; set; }

        public DateTime DayOfBirth { get; set; }

        public IEnumerable<DalVisaInfo> Visa { get; set; }

    }
}
