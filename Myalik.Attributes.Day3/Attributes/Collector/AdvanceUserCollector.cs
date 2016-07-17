using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Attributes.Collector.Interface;
using Attributes.CustomAttributes;
using Attributes.Entities;
using Attributes.AttributesValidator;

namespace Attributes.Collector
{
    public class AdvanceUserCollector : AttributesValidator<AdvancedUser>, ICollector<AdvancedUser>
    {
        public IEnumerable<AdvancedUser> CreateEntityFromAssembly()
        {
            var result = new List<AdvancedUser>();
            var assembly = Assembly.GetExecutingAssembly();
            var type = typeof(AdvancedUser);
            var attributes = (IEnumerable<InstantiateAdvancedUserAttribute>)assembly.GetCustomAttributes(typeof(InstantiateAdvancedUserAttribute));
            foreach (var attr in attributes)
            {
                if (attr.ID == null)
                    attr.ID = GetAttributesId(type, "id");
                if (attr.ExternalID == null)
                    attr.ExternalID = GetAttributesId(type, "externalId");
                if (attr.ID == null) continue;
                if (attr.ExternalID != null)
                    result.Add(new AdvancedUser((int)attr.ID, (int)attr.ExternalID)
                    {
                        FirstName = attr.Name,
                        LastName = attr.LastName 
                    });
            }
            return result;
        }

        public IEnumerable<AdvancedUser> CreateEntityFromClass()
        {
            var result = new List<AdvancedUser>();
            var type = typeof(AdvancedUser);
            var attributes = (IEnumerable<InstantiateAdvancedUserAttribute>)type.
                GetCustomAttributes(typeof(InstantiateAdvancedUserAttribute));
            foreach (var attr in attributes)
            {
                if (attr.ID == null)
                    attr.ID = GetAttributesId(type, "id");
                if (attr.ExternalID == null)
                    attr.ExternalID = GetAttributesId(type, "externalId");
                if (attr.ID == null) continue;
                if (attr.ExternalID != null)
                    result.Add(new AdvancedUser((int)attr.ID, (int) attr.ExternalID)
                    {
                        FirstName = attr.Name,
                        LastName = attr.LastName
                    });
            }
            return result;
        }

        public int? GetAttributesId(Type type, string fieldName)
        {
            var ctors = type.GetConstructors();
            var attr = (MatchParameterWithPropertyAttribute)ctors.
                FirstOrDefault(e => e.GetCustomAttributes(typeof(MatchParameterWithPropertyAttribute)) != null).
                GetCustomAttributes(typeof(MatchParameterWithPropertyAttribute)).
                FirstOrDefault(e => ((MatchParameterWithPropertyAttribute)e).FieldName == fieldName);
            if (attr == null) return null;
            var value = (int)((DefaultValueAttribute)type.GetProperty(attr.PropertyName).
                GetCustomAttribute(typeof(DefaultValueAttribute))).Value;
            return value;
        }

    }
}
