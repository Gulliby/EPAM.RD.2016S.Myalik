﻿using BLL.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class BllVisaInfo : IBllEnitity
    {
        public int Id { get; }

        public BllCountry Country { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

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