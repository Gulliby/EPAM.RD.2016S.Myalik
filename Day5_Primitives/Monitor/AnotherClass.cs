using System;
using System.Threading;

namespace MyMonitor
{
    // TODO: Use SpinLock to protect this structure.
    public class AnotherClass
    {
        private int _value;
        private SpinLock sp = new SpinLock();
        
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
            bool incLock = false;
            try
            {
                sp.Enter(ref incLock);
                _value++;
            }
            finally
            {
                if (incLock)
                    sp.Exit();
                incLock = false;
            }
        }

        public void Decrease()
        {
            bool incLock = false;
            try
            {
                sp.Enter(ref incLock);
                _value--;
            }
            finally
            {
                if (incLock)
                    sp.Exit();
                incLock = false;
            }
        }
    }
}
