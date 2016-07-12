using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public IEnumerable<VisaInfo> Visa { get; private set; }
        
        public User()
        {

        }

        public override bool Equals(object obj)
        {
            var item = obj as User;
            if (item == null)
            {
                return false;
            }
            return Equals(item);
        }

        private bool Equals(User user)
        {
            var visaFlag = new HashSet<VisaInfo>(Visa).SetEquals(new HashSet<VisaInfo>(user.Visa));
            return ((Name == user.Name) 
                && (LastName == user.LastName) 
                && (Gender == user.Gender)) && visaFlag;
        }

        public override int GetHashCode()
        {
            return Id ^ (Name.Length + (byte)Name[0]) 
                ^ (LastName.Length + (byte)LastName[0]) 
                ^ (int)Gender;
        }
    }
}
