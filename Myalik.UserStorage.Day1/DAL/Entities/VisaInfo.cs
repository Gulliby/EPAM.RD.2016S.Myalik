using DAL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public struct VisaInfo : IEntity
    {
        public int Id { get; set; }

        public Country Country { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is VisaInfo))
            {
                return false;
            }
            var item = (VisaInfo)obj;
            return Equals(item);
        }

        private bool Equals(VisaInfo visaInfo)
        {
            return (Country.Equals(visaInfo.Country) 
                && Start.Equals(visaInfo.Start) 
                && End.Equals(visaInfo.End));
        }

        public override int GetHashCode()
        {
            return Id ^ Country.GetHashCode() 
                ^ Start.GetHashCode() 
                ^ End.GetHashCode();
        }
    }
}
