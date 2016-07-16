using System;

namespace Attributes.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class InstantiateAdvancedUserAttribute : InstantiateUserAttribute
    {
        public int? ExternalID { get; set; }

        public InstantiateAdvancedUserAttribute(string name, string lastName) : base(name, lastName) { }

        public InstantiateAdvancedUserAttribute(int id, string name, string lastName, int extId) : base(id, name, lastName)
        {
            ExternalID = extId;
        }
    }
}
