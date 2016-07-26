using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.MainBllLogger;
using BLL.Services;
using Configurator.Configurators;

namespace Client
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var conf = new ServiceConfigurator();
            var connections = new List<IPEndPoint>
            {
                new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555),
                new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55556),
                new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55557),
                new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55558)
            };

            MasterService master;
            IList<SlaveService> slaves;
            conf.Config(1, 4, "file.xml",connections, out master, out slaves);

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
                    master.AddEntity(user);
                    var users = master.GetAll();
                    PrintUsers("Users in MASTER now:", users);
                    Thread.Sleep(1000);
                }
            };

            WaitCallback slaveCallback = p =>
            {
                start.Wait(token);
                var slave = (SlaveService)p;
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;
                    var users = slave.GetAll().ToList();
                    PrintUsers("Users in SLAVE now:", users);
                    Thread.Sleep(1000);
                }
            };

            ThreadPool.QueueUserWorkItem(masterCallback, master);
            foreach (var s in slaves)
                ThreadPool.QueueUserWorkItem(slaveCallback, s);
            

            start.Set();
            Console.ReadLine();
            cts.Cancel();
            master.Commit();
            Console.ReadLine();
        }

        private static BllUser GenerateUser()
        {
            var result = new BllUser
            {
                Name = RandomString(7),
                LastName = RandomString(7),
                DayOfBirth = DateTime.FromBinary(random.Next()),
                PersonalId = RandomString(7)
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
                Console.WriteLine("{0}. {1}", i + 1, bllUsers[i]);
            }
        }

       
    }
}
