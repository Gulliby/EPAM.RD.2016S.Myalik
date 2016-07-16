using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Exceptions;
using Generator.Generators.Interface;

namespace Generator.Generators
{
    [Serializable]
    public class IdGenerator : IGenerator
    {
        public int generatedId { get; private set; }
        private static readonly object syncRoot = new object();

        public IEnumerable<int> Generate()
        {
            for (generatedId = generatedId; generatedId < int.MaxValue; generatedId++)
            {
                lock (syncRoot)
                {
                    yield return generatedId;
                }
            }
            throw new IndexCantBeCreatedException(nameof(generatedId));
        }

        public IdGenerator(int idPost)
        {
            lock (syncRoot)
            {
                generatedId = idPost;
            }
        }

        public object Clone()
        {
            return new IdGenerator(generatedId);
        }
    }
}
