using DAL.Generator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generator
{
    public class IdGenerator : IIdGenerator
    {
        private static volatile IdGenerator instance;
        private static object syncRoot = new object();

        private IdGenerator() { }

        public static IdGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new IdGenerator();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<int> Generate()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                lock (syncRoot)
                {
                    yield return i;
                }
            }
        }
    }
}
