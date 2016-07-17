using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attributes.Entities;
using Attributes.AttributesValidator.Interface;

namespace Attributes.AttributesValidator
{
    public class AttributesValidator<TEntity> : IValidator<TEntity>
        where TEntity : User
    {
        public bool ValidateEntity(TEntity user, out List<ValidationResult> results)
        {
            var result = true;
            results = new List<ValidationResult>();
            var type = user.GetType();
            var props = type.GetProperties()
                .Where(e => e.GetCustomAttributes(typeof(ValidationAttribute)).Count() != 0);
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(e => e.GetCustomAttributes(typeof(ValidationAttribute)).Count() != 0);
            foreach (var prop in props)
            {
                var validateProp = ValidateProperty(user, prop, ref results);
                result = result && validateProp;
            }
            foreach (var field in fields)
            {
                var validateField = ValidateField(user, field, ref results);
                result = result && validateField;
            }
            return result;
        }

        public bool ValidateField(TEntity user, FieldInfo info, ref List<ValidationResult> results)
        {
            var value = info.GetValue(user);
            var context = new ValidationContext(value, null, null);
            var attributes = (IEnumerable<ValidationAttribute>)info.GetCustomAttributes(typeof(ValidationAttribute));
            return Validator.TryValidateValue(value, context, results, attributes);
        }

        public bool ValidateProperty(TEntity user, PropertyInfo info, ref List<ValidationResult> results)
        {
            var value = info.GetValue(user);
            var context = new ValidationContext(value, null, null);
            var attributes = (IEnumerable<ValidationAttribute>)info.GetCustomAttributes(typeof(ValidationAttribute));
            return Validator.TryValidateValue(value, context, results, attributes);
        }

    }
}
