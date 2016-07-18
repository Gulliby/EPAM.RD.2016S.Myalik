namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var myClass = new MyClass())
            {
                // NOTE: Don't change the code in this file.
                myClass.DoSomething();
                myClass.Dispose();
                myClass.DoSomething();
            }
        }
    }
}
