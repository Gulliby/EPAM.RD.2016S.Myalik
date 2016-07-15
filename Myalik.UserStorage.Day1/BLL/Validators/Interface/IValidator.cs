using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Validators.Interface
{
    public interface IValidator<in TEntity> 
        where TEntity : IBllEnitity
    {
        bool Validate(TEntity entity);
    }
}
