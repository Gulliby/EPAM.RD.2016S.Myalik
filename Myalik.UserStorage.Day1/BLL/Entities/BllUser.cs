using BLL.Entities.Interface;
using System;
using System.Collections.Generic;

namespace BLL.Entities
{
    [Serializable]
    public class BllUser : IBllEnitity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }

        public BllGender Gender { get; set; }

        public DateTime DayOfBirth { get; set; }

        public List<BllVisaInfo> Visa { get; set; }


        public override bool Equals(object obj)
        {
            var item = obj as BllUser;
            return item != null && Equals(item);
        }

        private bool Equals(BllUser user)
        {
            var visaFlag = true;
            if ((Visa != null) && (user.Visa != null))
                visaFlag = new HashSet<BllVisaInfo>(Visa).SetEquals(new HashSet<BllVisaInfo>(user.Visa));
            return (Name == user.Name)
                && (LastName == user.LastName)
                && (Gender == user.Gender)
                && DayOfBirth.Equals(user.DayOfBirth)
                && (PersonalId == user.PersonalId)
                && visaFlag;
        }

        public override int GetHashCode()
        {
            return Id ^ (Name.Length + (byte)Name[0])
                ^ (LastName.Length + (byte)LastName[0])
                ^ (int)Gender ^ PersonalId.GetHashCode();
        }
    }
}
