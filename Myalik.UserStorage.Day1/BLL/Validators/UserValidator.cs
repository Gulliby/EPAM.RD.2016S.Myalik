using System;
using BLL.Entities;
using BLL.Validators.Interface;

namespace BLL.Validators
{
    [Serializable] 
    public class UserValidator : IValidator<BllUser>
    {
        public bool Validate(BllUser entity)
        {
            return entity.Name != string.Empty;
        }
    }
}
