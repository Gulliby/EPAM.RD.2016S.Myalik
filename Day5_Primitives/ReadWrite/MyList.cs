using System;
using System.Collections.Generic;
using System.Threading;

namespace ReadWrite
{
    // TODO: Use ReaderWriterLockSlim to protect this class.
    public class MyList
    {
        private List<int> _list = new List<int>()
        {
            1,
            2,
            3,
            4
        };

        private ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        public void Add(int value)
        {
            try
            {
                _readerWriterLock.EnterWriteLock();
                Console.WriteLine("Write");
                _list.Add(value);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public void Remove()
        {
            try
            {
                _readerWriterLock.EnterWriteLock();
                if (_list.Count > 0)
                {
                    Console.WriteLine("Write");
                    _list.RemoveAt(0);
                }
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public int Get()
        {
            try
            {
                _readerWriterLock.EnterReadLock();
                int value = 0;
                if (_list.Count > 0)
                {
                    Console.WriteLine("Read");
                    value = _list[0];
                }

                return value;
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }
    }
}
