using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attributes.AttributesValidator;
using Attributes.Collector.Interface;
using Attributes.CustomAttributes;
using Attributes.Entities;

namespace Attributes.Collector
{
    public class UserCollector : AttributesValidator<User>, ICollector<User>
    {
        public IEnumerable<User> CreateEntityFromAssembly()
        {
            var result = new List<User>();
            var assembly = Assembly.GetExecutingAssembly();
            var type = typeof(User);
            var attributes = (IEnumerable<InstantiateUserAttribute>)assembly.GetCustomAttributes(typeof(InstantiateUserAttribute));
            foreach (var attr in attributes)
            {
                if (attr.ID == null)
                    attr.ID = GetAttributesId(type, "id");
                if (attr.ID == null) continue;
                    result.Add(new User((int)attr.ID)
                    {
                        FirstName = attr.Name,
                        LastName = attr.LastName
                    });
            }
            return result;
        }

        public IEnumerable<User> CreateEntityFromClass()
        {
            var result = new List<User>();
            var type = typeof(User);
            var attributes = (IEnumerable<InstantiateUserAttribute>)type.
                GetCustomAttributes(typeof(InstantiateUserAttribute));
            foreach (var attr in attributes)
            {
                if (attr.ID == null)
                    attr.ID = GetAttributesId(type, "id");
                if (attr.ID != null)
                    result.Add(new User((int)attr.ID)
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
