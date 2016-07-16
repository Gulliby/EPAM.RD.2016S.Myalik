using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Serializable]
    public struct DalVisaInfo : IDalEntity
    {
        public int Id { get; set; }

        public DalCountry Country { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public object Clone()
        {
            return new DalVisaInfo()
            {
                Country = (DalCountry) Country.Clone(),
                End = End,
                Id = Id,
                Start = Start
            };
        }
    }
}
