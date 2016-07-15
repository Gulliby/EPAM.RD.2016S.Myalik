using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Validators.Interface;

namespace BLL.Validators
{
    public class UserValidator : IValidator<BllUser>
    {
        public bool Validate(BllUser entity)
        {
            return entity.Visa != null;
        }
    }
}
