using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attributes.Entities;

namespace Attributes.AttributesValidator.Interface
{
    public interface IValidator<in TEntity> where TEntity : User
    {
        bool ValidateEntity(TEntity user, out List<ValidationResult> results);

        bool ValidateField(TEntity user, FieldInfo info, ref List<ValidationResult> results);

        bool ValidateProperty(TEntity user, PropertyInfo info, ref List<ValidationResult> results);
    }
}
