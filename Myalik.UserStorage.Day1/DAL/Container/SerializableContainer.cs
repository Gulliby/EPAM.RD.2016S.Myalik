using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Interface;
using DAL.Repositories.Interface;
using Generator.Generators;
using Generator.Generators.Interface;

namespace DAL.Container
{
    public class SerializableContainer<TEntity> 
        where TEntity: IDalEntity
    {
        public IEnumerator<int> Generator { get; set; }

        public IList<TEntity> Users { get; set; } 
    }
}
