using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Engine.IO.Client;

namespace Engine.IO.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ws = new EngineWebSocket();
            ws.ConnectAsync(new Uri("http://localhost:3000/engine.io")).Wait();

            Console.ReadLine();
        }
    }
}
