﻿using BLL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    [Serializable]
    public class BllVisaInfo : IBllEnitity
    {
        public int Id { get; }

        public BllCountry Country { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is BllVisaInfo))
            {
                return false;
            }
            var item = (BllVisaInfo)obj;
            return Equals(item);
        }

        private bool Equals(BllVisaInfo visaInfo)
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
