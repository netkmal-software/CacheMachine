using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMachine.Interfaces.CacheClient
{
    public interface ICacheClientFactory
    {
        IConfigureCacheClient Configure();
        ICacheClient Build();
    }
}
