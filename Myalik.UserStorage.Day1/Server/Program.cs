using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.AppConfig.ConnectionConfig;
using Server.AppConfig.FileConfig;
using Server.AppConfig.ServiceConfig;
using Server.Collector;
using ServiceProxy.Proxies;
using WcfService;
using WcfService.Configuration;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool createdNew;
            var mutex = new Mutex(true, "day5", out createdNew);
            var baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WcfService/UserService/");
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

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
            
            Console.WriteLine("Master state was saved");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
