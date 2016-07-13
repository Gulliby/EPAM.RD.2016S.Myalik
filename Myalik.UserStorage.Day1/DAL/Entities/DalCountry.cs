using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DalCountry : IDalEntity
    {
        #region Properties

        public int Id { get; set; }

        public string ISO { get; set; }

        public string Name { get; set; }

        public int PhoneCode { get; set; }

        #endregion
    }
}
