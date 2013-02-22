using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CacheMachine.Core.Server
{
    public class CacheServer
    {
        private static NLog.Logger _logger = new NLog.LogFactory().GetCurrentClassLogger();

        const int MAX_CLIENTS = 10;

        public string IpAddress { get; set; }

        public int Port { get; set; }

        protected TcpListener Listener;

        public void Start()
        {
            
        }

        
    }
}
