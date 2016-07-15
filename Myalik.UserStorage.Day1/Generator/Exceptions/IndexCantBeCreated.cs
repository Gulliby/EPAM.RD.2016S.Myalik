using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Exceptions
{
    public class IndexCantBeCreated : Exception
    {
        public IndexCantBeCreated()
        {
        }

        public IndexCantBeCreated(string message)
            : base(message)
        {
        }

        public IndexCantBeCreated(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
