using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda1 =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanFive,
                    new ParameterExpression[] { numParam });
            var func = lambda1.Compile();
            Predicate<int> func2 = (int num) => { return num < 5; };
            Console.WriteLine(func(1));
            Console.WriteLine(func(9));
            Console.WriteLine(func2(1));
            Console.WriteLine(func2(9));
            Console.Write(lambda1.ToString() + "\nYa horoshiy programmist \n" + func.ToString());
            Console.Read();
        }
    }
}
