using System;
using MyClassLibrary;

namespace TaskConsole
{
  public class Work
  {
    public void DoSomething(ImportantEnum importantEnum)
    {
      switch (importantEnum)
      {
        case ImportantEnum.Red:
          DoWorkRed();
          break;
        case ImportantEnum.Orange:
          DoWorkOrange();
          break;

        case ImportantEnum.Green:
          DoWorkGreen();
          break;
      }
    }

    private void DoWorkRed()
    {
      Console.WriteLine("Red");
    }

    private void DoWorkOrange()
    {
      Console.WriteLine("Orange");
    }

    private void DoWorkGreen()
    {
      Console.WriteLine("Green");
    }
  }
}
