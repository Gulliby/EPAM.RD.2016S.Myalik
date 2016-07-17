using MyInterfaces;

namespace MyLibrary
{
    [DoSomething]
    public class AnotherService
    {
        public Result DoSomething(Input input)
        {
            return new Result
            {
                Value = input.Users.Length
            };
        }
    }
}
