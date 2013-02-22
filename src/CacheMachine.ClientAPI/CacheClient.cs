using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CacheMachine.Common.Serialization;
using CacheMachine.Interfaces.CacheClient;
using CacheMachine.Interfaces.Commands;

namespace CacheMachine.ClientAPI
{
    public class CacheClient : ICacheClient,  ICacheClientOperations
    {
        private static NLog.Logger _logger = new NLog.LogFactory().GetCurrentClassLogger();

        private readonly TcpClient _tcpClient;

        public CacheClient(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        #region ICacheClientOperations Implementation

        public void Dispose()
        {
            _tcpClient.Close();
            GC.Collect();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public long Increment(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public long Decrement(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value)
        {
            using (var socket = _tcpClient.Client)
            {
                try
                {
                    var addCommand = new AddCommand { Key = key, Value = value, ExpiresAt = DateTime.MaxValue};
                    socket.Send(addCommand.ObjectToByteArray());
                }
                catch (SocketException ex)
                {
                    _logger.ErrorException(ex.Message, ex);
                    throw;
                }
            }
            
            return true;
        }

        public bool Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICacheClient Implementation

        public ICacheClientOperations Operations()
        {
            return this;
        }

        #endregion

    }
}
