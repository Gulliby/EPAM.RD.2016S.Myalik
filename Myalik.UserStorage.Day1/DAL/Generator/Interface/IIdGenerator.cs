using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generator.Interface
{
    public interface IIdGenerator
    {
        IEnumerable<int> Generate();
    }
}
