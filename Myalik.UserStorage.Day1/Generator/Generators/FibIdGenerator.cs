using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Generators
{
    [Serializable]
    public class FibIterator : IEnumerator<int>
    {
        private int prev;
        private int current;

        public FibIterator(int current, int prev)
        {
            this.current = current;
            this.prev = prev;
        }

        public FibIterator() : this(1, 0) { }

        public int Prev { get { return prev; } }

        public int Current{ get; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (int.MaxValue - current < prev)
                return false;
            int temp = prev + current;
            prev = current;
            current = temp;
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
