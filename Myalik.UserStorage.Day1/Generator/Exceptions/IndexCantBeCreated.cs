using System;

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
