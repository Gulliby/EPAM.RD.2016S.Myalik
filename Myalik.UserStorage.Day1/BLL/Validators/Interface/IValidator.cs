using BLL.Entities.Interface;

namespace BLL.Validators.Interface
{
    public interface IValidator<in TEntity> 
        where TEntity : IBllEnitity
    {
        bool Validate(TEntity entity);
    }
}
