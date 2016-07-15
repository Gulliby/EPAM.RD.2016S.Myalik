using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Generators.Interface;

namespace Generator.Generators
{
    public class IdGenerator : IGenerator
    {
        private static readonly object syncRoot = new object();

        public IEnumerable<int> Generate()
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                lock (syncRoot)
                {
                    yield return i;
                }
            }
        }
    }
}
