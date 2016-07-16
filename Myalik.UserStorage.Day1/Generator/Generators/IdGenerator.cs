using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Generators.Interface;

namespace Generator.Generators
{
    [Serializable]
    public class IdGenerator : IGenerator
    {
        private int generatedId;
        private static readonly object syncRoot = new object();
        public IEnumerable<int> Generate()
        {
            for (generatedId = 0; generatedId < int.MaxValue; generatedId++)
            {
                lock (syncRoot)
                {
                    yield return generatedId;
                }
            }
        }

        public object Clone()
        {
            return new IdGenerator
            {
                generatedId = generatedId
            };
        }
    }
}
