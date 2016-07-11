using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
{
    public static class FibonachiEnumerable
    {
        public static IEnumerable<long> GetFibonachi()
        {
            var fivbEter = new FibIterator();
            while (fivbEter.MoveNext())
                yield return fivbEter.Current;
            yield break; 
        }
    }

    public class FibIterator : IEnumerator<long>
    {
        private long prev = 0;
        private long current = 1;

        public long Current
        {
            get
            {
                long temp = prev + current;
                prev = current;
                long currentTemp = current;
                current = temp;
                return currentTemp;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }

        }

        public bool MoveNext()
        {
            if (long.MaxValue - current < prev)
                return false;
            return true;
        }

        public void Reset()
        {
            prev = 0; 
            current = 1;
        }

        public void Dispose()
        {
            prev = current = 0;
        }
    }
}
