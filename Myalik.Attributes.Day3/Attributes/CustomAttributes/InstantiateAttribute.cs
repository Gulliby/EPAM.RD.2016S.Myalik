using System;

namespace Attributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InstantiateUserAttribute : Attribute
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public InstantiateUserAttribute(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public InstantiateUserAttribute(int id, string name, string lastName) : this(name, lastName)
        {
            ID = id;
        }
    }
}
