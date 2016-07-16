using System;
using System.ComponentModel.DataAnnotations;

namespace Attributes.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class StringValidatorAttribute : ValidationAttribute
    {
        public int LengthLimit { get; set; }

        public StringValidatorAttribute(int lengthLimit)
        {
            LengthLimit = lengthLimit;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            var str = (string)value;
            return str.Length <= LengthLimit;
        }
    }
}
