using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonachi;
namespace Fibonachi_Project_11_07
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterator = new FibIterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
                Console.ReadKey();
            }
        }
    }
}
