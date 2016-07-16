using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Entities.Interface;
using DAL.Repositories.Interface;
using Generator.Generators;
using Generator.Generators.Interface;

namespace DAL.Container
{
    public class UserSerializableContainer
    {
        public int IdPos { get; set; }

        public List<DalUser> Users { get; set; } 
    }
}
