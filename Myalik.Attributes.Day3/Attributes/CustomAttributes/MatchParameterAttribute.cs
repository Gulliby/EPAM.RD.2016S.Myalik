using System;

namespace Attributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
    public class MatchParameterWithPropertyAttribute : Attribute
    {
        public string FieldName { get; set; }

        public string PropertyName { get; set; }

        public MatchParameterWithPropertyAttribute(string fieldName, string propertyName)
        {
            FieldName = fieldName;
            PropertyName = propertyName;
        }
    }
}
