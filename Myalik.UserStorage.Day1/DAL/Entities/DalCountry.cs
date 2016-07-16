using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Serializable]
    public class DalCountry : IDalEntity
    {
        #region Properties

        public int Id { get; set; }

        public string ISO { get; set; }

        public string Name { get; set; }

        public int PhoneCode { get; set; }

        #endregion

        public object Clone()
        {
            return new DalCountry()
            {
                Id = Id,
                ISO = string.Copy(ISO),
                Name = string.Copy(Name),
                PhoneCode = PhoneCode
            };
        }
    }
}
