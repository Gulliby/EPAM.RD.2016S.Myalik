using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonachi;
using System.Linq;
using System.Linq.Expressions;
namespace FobonachiTest
{
    [TestClass]
    public class FibonachiUnitTest
    {
        [TestMethod]
        public void FibonachiEnumerator_TestMethod()
        {
            var result = FibonachiEnumerable.GetFibonachi();
            CollectionAssert.AreEqual(result.Take(10).ToArray(), new long[10] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 });
        }
        [TestMethod]
        public void FibonachiEnumerator_Contains5_TestMethod()
        {
            var result = FibonachiEnumerable.GetFibonachi();
            CollectionAssert.Contains(result.ToArray(), (long)5);
        }
    }
}
