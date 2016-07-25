using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Generators.Interface;

namespace Generator.Generators
{
    [Serializable]
    public class FibIterator : IEnumerator<int>,IGenerator
    {

        public FibIterator(int current, int prev)
        {
            Current = current;
            Prev = prev;
        }

        public FibIterator() : this(1, 0) { }

        public int Prev { get; private set; }

        public int Current{ get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (int.MaxValue - Current < Prev)
                return false;
            var temp = Prev + Current;
            Prev = Current;
            Current = temp;
            return true;
        }

        public void Reset()
        {
            Prev = 0;
            Current = 1;
        }

        public void Dispose()
        {
            Prev = Current = 0;
        }

        public object Clone()
        {
            return new FibIterator(Current, Prev);
        }
    }
}
