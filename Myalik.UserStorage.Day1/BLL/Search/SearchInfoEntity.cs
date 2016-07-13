using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Search
{
    public class SearchInfoEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public BllGender Gender { get; set; }

    }
}
