using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Attributes.AttributesValidator.Interface;
using Attributes.Entities;

namespace Attributes.Collector.Interface
{
    public interface ICollector<TEntity> : IValidator<TEntity>
        where TEntity : User
    {
        IEnumerable<TEntity> CreateEntityFromAssembly();

        IEnumerable<TEntity> CreateEntityFromClass();


        int? GetAttributesId(Type type, string fieldName);
    }
}
