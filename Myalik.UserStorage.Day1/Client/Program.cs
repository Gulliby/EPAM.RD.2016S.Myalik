// <copyright file="Program.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BLL.Entities;

    /// <summary>
    /// Entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Random instance.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments instance.</param>
        public static void Main(string[] args)
        {
            Mutex mutex;
            while (!Mutex.TryOpenExisting("day5", out mutex))
            {
                Thread.Sleep(100);
            }

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
                    {
                        break;
                    }

                    var user = GenerateUser();
                    Console.WriteLine("One more user will be adeed MASTER.");
                    service.Add(user);
                    var users = service.GetAll();
                    PrintUsers("Users now:", users);
                    Thread.Sleep(1000);
                }
            };

            for (var i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(masterCallback);
            }

            start.Set();
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
        }

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <param name="length">Length of string.</param>
        /// <returns>Generated string.</returns>
        public static string RandomString(int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generate a random user.
        /// </summary>
        /// <returns>Random user.</returns>
        private static BllUser GenerateUser()
        {
            var result = new BllUser
            {
                Name = RandomString(7),
                LastName = RandomString(7),
                DayOfBirth = DateTime.FromBinary(Random.Next()),
                PersonalId = RandomString(7),
                Gender = BllGender.Female,
            };
            return result;
        }

        /// <summary>
        /// Print a user to the console.
        /// </summary>
        /// <param name="message">Message which need to be printed.</param>
        /// <param name="users">User which need to be printed.</param>
        private static void PrintUsers(string message, IEnumerable<BllUser> users)
        {
            Console.WriteLine(message);
            var bllUsers = users as BllUser[] ?? users.ToArray();
            for (var i = 0; i < bllUsers.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, bllUsers[i].Id);
            }
        }     
    }
}
