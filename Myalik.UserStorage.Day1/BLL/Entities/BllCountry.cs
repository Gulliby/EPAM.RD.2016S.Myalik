using BLL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    [Serializable]
    public class BllCountry : IBllEnitity
    {
        #region Properties

        public int Id { get; set; }

        public string ISO { get; set; }

        public string Name { get; set; }

        public int PhoneCode { get; set; }

        #endregion

        public override bool Equals(object obj)
        {
            var item = obj as BllCountry;
            return item != null && Equals(item);
        }

        private bool Equals(BllCountry country)
        {
            return (ISO == country.ISO)
                && (Name == country.Name)
                && (PhoneCode == country.PhoneCode);
        }

        public override int GetHashCode()
        {
            return Id ^ (ISO.Length + (byte)ISO[0])
                ^ (Name.Length + (byte)Name[0])
                ^ PhoneCode;
        }
    }
}
