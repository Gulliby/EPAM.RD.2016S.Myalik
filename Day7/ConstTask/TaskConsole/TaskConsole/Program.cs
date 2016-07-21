using System;

namespace TaskConsole
{

  class Program
  {
    static void Main(string[] args)
    {
      int time = 20;

      if (time > MyClassLibrary.Helpers.WaitTime)
      {
        Console.WriteLine("time : {0} > Wait Time {1}", time, MyClassLibrary.Helpers.WaitTime);
      }
      else
      {
        Console.WriteLine("time : {0} <= Wait Time {1}", time, MyClassLibrary.Helpers.WaitTime);
      }

      Console.WriteLine("========================================================");

      var result = MyClassLibrary.GetResult.GetUserResult("Red");

      var work = new Work();
      work.DoSomething(result);

      Console.ReadLine();
    }
  }
}
