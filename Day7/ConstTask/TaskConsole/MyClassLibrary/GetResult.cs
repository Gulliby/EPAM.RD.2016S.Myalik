using System;

namespace MyClassLibrary
{
  public class GetResult
  {
    public static ImportantEnum GetUserResult(string str)
    {
      if (str.Contains("Red"))
      {
        Console.WriteLine((int)ImportantEnum.Red);
        return ImportantEnum.Red;
      }
      if (str.Length > 3)
      {
        return ImportantEnum.Green;
      }
      return ImportantEnum.Orange;
    }
  }
}
