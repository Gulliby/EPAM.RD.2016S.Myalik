using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Exceptions
{
    public class IndexCantBeCreatedException : Exception
    {
        public IndexCantBeCreatedException()
        {
        }

        public IndexCantBeCreatedException(string message)
            : base(message)
        {
        }

        public IndexCantBeCreatedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
