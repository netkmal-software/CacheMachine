using System;
using System.Net.Sockets;
using CacheMachine.Interfaces.CacheClient;

namespace CacheMachine.ClientAPI
{
    public class CacheClientFactory : ICacheClientFactory, IConfigureCacheClient
    {
        private static NLog.Logger _logger = new NLog.LogFactory().GetCurrentClassLogger();

        protected CacheClientConfiguration Configuration { get; set; }

        public CacheClientFactory()
        {
            // set the default settings
            Configuration = new CacheClientConfiguration
                {
                    HostName = "127.0.0.1",
                    Port = 9095
                };
        }

        public ICacheClient Build()
        {
            try
            {
                return new CacheClient(new TcpClient(Configuration.HostName, Configuration.Port));
            }
            catch (SocketException ex)
            {
                _logger.ErrorException(ex.Message, ex);
                throw;
            }
        }

        public IConfigureCacheClient Configure()
        {
            return this;
        }

        public IConfigureCacheClient Port(int port)
        {
            Configuration.Port = port;
            return this;
        }

        public IConfigureCacheClient HostName(string hostName)
        {
            Configuration.HostName = hostName;
            return this;
        }

        public ICacheClientFactory Initialize()
        {
            return this;
        }
    }
}