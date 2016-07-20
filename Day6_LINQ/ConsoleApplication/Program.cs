using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Millisecond);
            string a = "";
            for (int i = 0; i < 5; i++)
                a += "1";
            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(DateTime.Now.Millisecond);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
                sb.Append("1");
            Console.WriteLine(DateTime.Now.Millisecond);
            Console.Read();
        }

    }
}
