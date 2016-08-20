// <copyright file="Program.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Server
{
    using System;
    using System.ServiceModel.Description;
    using System.Threading;
    using Collector;
    using WcfServiceLibrary;
    using WcfServiceLibrary.Configuration;

    /// <summary>
    /// Entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments instance.</param>
        public static void Main(string[] args)
        {
            bool createdNew;
            var mutex = new Mutex(true, "day5", out createdNew);
            
            // Taked from https://habrahabr.ru/
            var baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/UserService/");
            var proxy = ProxyCollector.GetConfigedServiceProxy();
            using (var host = new ServiceServerHost(proxy, typeof(UserService), baseAddress))
            {
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter =
                    {
                        PolicyVersion = PolicyVersion.Default
                    }
                };
                host.Description.Behaviors.Add(smb);
                host.Open();

                mutex.ReleaseMutex();

                Console.WriteLine("Started at {0}", baseAddress);
                Console.WriteLine("Press any button to stop service :");
                Console.ReadKey();

                host.Close();
            }
            
            Console.WriteLine("Master saved");
            proxy.Commit();
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
        }
    }
}
