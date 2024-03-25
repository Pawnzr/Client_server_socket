using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerSocket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 1234);
            // IPAddress.Any == 0.0.0.0
            Socket server_socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server_socket.Bind(ipe);
            server_socket.Listen(5);

            Socket client_socket = server_socket.Accept();
            Console.WriteLine("[+] Get Connection from: {0}", client_socket.LocalEndPoint);
            Console.WriteLine("Enter message to send: ");
            string msg = Console.ReadLine();
            client_socket.Send(Encoding.ASCII.GetBytes(msg));
            client_socket.Close();
            server_socket.Close();
            Console.ReadKey();

        }

    }
}
