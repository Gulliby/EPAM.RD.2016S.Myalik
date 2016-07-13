using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public struct DalVisaInfo : IDalEntity
    {
        public int Id { get; set; }

        public DalCountry Country { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

    }
}
