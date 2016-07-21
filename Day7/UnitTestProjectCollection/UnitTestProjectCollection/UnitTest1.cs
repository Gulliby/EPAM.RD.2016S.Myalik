using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectCollection
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var temp = new BlockCollClass();
      try
      {
        temp.Start();
      }
      catch (Exception)
      {
        Assert.Fail();
      }
      
    }
  }
}
