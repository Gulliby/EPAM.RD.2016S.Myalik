using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BLL.Entities;

namespace Client
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            //day5
            Mutex mutex;
            while (!Mutex.TryOpenExisting("day5", out mutex))
                Thread.Sleep(100);
            mutex.WaitOne();

            var service = new ServiceReference.UserServiceClient();

            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var start = new ManualResetEventSlim(false);
            
            WaitCallback masterCallback = p =>
            {
                start.Wait(token);
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;
                    var user = GenerateUser();
                    Console.WriteLine("One more user will be adeed MASTER.");
                    service.Add(user);
                    var users = service.GetAll();
                    PrintUsers("Users now:", users);
                    Thread.Sleep(1000);
                }
            };

            for (var i = 0; i < 3; i++)
                ThreadPool.QueueUserWorkItem(masterCallback);


            start.Set();
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
        }

        private static BllUser GenerateUser()
        {
            var result = new BllUser
            {
                Name = RandomString(7),
                LastName = RandomString(7),
                DayOfBirth = DateTime.FromBinary(random.Next()),
                PersonalId = RandomString(7),
                Gender = BllGender.Female,
            };
            return result;

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void PrintUsers(string message, IEnumerable<BllUser> users)
        {
            Console.WriteLine(message);
            var bllUsers = users as BllUser[] ?? users.ToArray();
            for(var i = 0; i < bllUsers.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, bllUsers[i].Id);
            }
        }

       
    }
}
