using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Services.Interface
{
    public interface ISearchable<out TEntity> 
        where TEntity : IBllEnitity
    {
        IEnumerable<TEntity> SearchEntityByName(string name);

        IEnumerable<TEntity> SearchEntityByLastName(string lastName);

        IEnumerable<TEntity> SearchEntityByNameAndLastName(string name, string lastName);

        IEnumerable<TEntity> GetAll();
    }
}
