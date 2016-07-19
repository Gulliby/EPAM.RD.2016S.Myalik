using System;
using System.Collections.Generic;
using System.Threading;

namespace MyMonitor
{
    public class Program
    {
        private static IList<Thread> CreateWorkers(EventWaitHandle ewh, Action action, int threadsNum, int cycles)
        {
            var threads = new Thread[threadsNum];

            for (int i = 0; i < threadsNum; i++)
            {
                Action d = () =>
                {
                    Console.WriteLine("Waiting");

                    // NOTE: all threads should wait here for a signal from the main thread.
                    ewh.WaitOne();

                    Console.WriteLine("Done");

                    for (int j = 0; j < cycles; j++)
                    {
                        action();
                    }
                };

                Thread thread = new Thread(new ThreadStart(d)); 
                // TODO: Create a new thread that will run the delegate above here.
                threads[i] = thread;
            }

            return threads;
        }

        public static void Main(string[] args)
        {
            EventWaitHandle ewh;

            ewh = new EventWaitHandle(false,EventResetMode.AutoReset); 
            // TODO: Choose between manual or auto reset events to synchronize threads.

            var myClass = new MyClass();
            var anClass = new AnotherClass();

            var threads = new List<Thread>();

            threads.AddRange(CreateWorkers(ewh, () => { myClass.Increase(); anClass.Decrease(); }, 10, 100000));
            threads.AddRange(CreateWorkers(ewh, () => { myClass.Decrease(); anClass.Increase(); }, 10, 100000));

            foreach (var thread in threads)
            {
                // TODO: Start all the threads.
                thread.Start();
            }

            Console.WriteLine("Press any key to run unblock working threads.");
            Console.ReadKey();

            // NOTE: When an user presses the key all waiting worker threads should begin their work.
            for (int i = 0; i < threads.Count; i++)
                ewh.Set();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("MyClass.Counter is " + myClass.Counter);
            Console.WriteLine("AnotherClass.Counter is " + anClass.Counter);
            Console.ReadKey();
        }
    }
}
