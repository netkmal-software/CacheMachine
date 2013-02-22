using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CacheMachine.ClientAPI;
using CacheMachine.Interfaces.CacheClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // start tcpip server
            ICacheClientFactory cacheClientFactory = new CacheClientFactory()
                .Configure()
                .HostName("127.0.0.1")
                .Port(9095)
                .Initialize();
                
            using (ICacheClient cacheClient = cacheClientFactory.Build())
            {
                cacheClient.Operations().Add("key", "hello");
            }

            Console.ReadKey();
        }
    }
}
