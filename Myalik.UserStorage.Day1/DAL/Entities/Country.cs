using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Country : IEntity
    {
        #region Properties

        public int Id { get; set; }

        public string ISO { get; set; }

        public string Name { get; set; }

        public int PhoneCode { get; set; }

        #endregion

        public override bool Equals(object obj)
        {
            var item = obj as Country;
            if (item == null)
            {
                return false;
            }
            return Equals(item);
        }

        private bool Equals(Country country)
        {
            return ((ISO == country.ISO)
                && (Name == country.Name) 
                && (PhoneCode == country.PhoneCode));
        }

        public override int GetHashCode()
        {
            return Id ^ (ISO.Length + (byte)ISO[0])
                ^ (Name.Length + (byte)Name[0])
                ^ PhoneCode;
        }
    }
}
