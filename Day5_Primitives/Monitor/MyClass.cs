using System;
using System.Threading;

namespace MyMonitor
{
    // TODO: Use Monitor (not lock) to protect this structure.
    public class MyClass
    {
        private int _value;
        object lockObj = new object();
        public int Counter
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void Increase()
        {
            Monitor.Enter(lockObj);
            try
            {
                _value++;
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }

        public void Decrease()
        {
            Monitor.Enter(lockObj);
            try
            {
                _value--;
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
        }
    }
}
