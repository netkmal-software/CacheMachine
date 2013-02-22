using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheMachine.Core.Transport
{
    public class SocketBus
    {
        private TcpClient _tcpClient;

        public SocketBus(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        public bool Send<T>(T command)
        {
            try
            {
                var socket = _tcpClient.Client;
                socket.Send(command.ObjectToByteArray());

                return true;
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.WouldBlock || ex.SocketErrorCode == SocketError.IOPending ||
                    ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
