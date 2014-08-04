using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.IO.Client
{
    public interface IEngineWebSocket
    {
        Task ConnectAsync(Uri uri);
        Task SendAsync(string message);
        void ReceiveAsync();
    }

    public class EngineWebSocket : IEngineWebSocket
    {
        protected ClientWebSocket WebSocket { get; set; }
        public EngineWebSocket()
        {
            WebSocket = new ClientWebSocket();
        }

        public async Task ConnectAsync(Uri uri)
        {
            var cts = new CancellationTokenSource();
            await WebSocket.ConnectAsync(uri, cts.Token);
        }

        public async Task SendAsync(string message)
        {
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            var cts = new CancellationTokenSource();
            await WebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, cts.Token);
        }

        public void ReceiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
