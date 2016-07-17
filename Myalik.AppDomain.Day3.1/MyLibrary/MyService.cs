using MyInterfaces;

namespace MyLibrary
{
    [DoSomething]
    public class MyService : IDoSomething
    {
        public Result DoSomething(Input input)
        {
            int total = 0;

            foreach (var item in input.Users)
            {
                total += item.Age;
            }

            return new Result
            {
                Value = total / input.Users.Length
            };
        }
    }
}
