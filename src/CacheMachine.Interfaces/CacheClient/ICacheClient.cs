using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMachine.Interfaces.CacheClient
{
    public interface ICacheClient : IDisposable
    {
        ICacheClientOperations Operations();
    }
}
