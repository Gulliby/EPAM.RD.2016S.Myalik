using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Container
{
    public class UserSerializableContainer
    {
        public int Current { get; set; }
        public int Prev { get; set; }
        public List<DalUser> Users { get; set; } 
    }
}
