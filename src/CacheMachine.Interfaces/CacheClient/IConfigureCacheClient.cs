using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMachine.Interfaces.CacheClient
{
    public interface IConfigureCacheClient
    {
        IConfigureCacheClient Port(int port);
        IConfigureCacheClient HostName(string hostName);
        ICacheClientFactory Initialize();
    }
}
