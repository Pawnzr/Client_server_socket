using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ClientSocket
{
    internal class Program
    {
        private static string msg;

        static void Main(string[] args)
        {
            IPAddress server_ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(server_ip, 1234);
            Socket cs = new Socket(server_ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            cs.Connect(ipe);
            byte[] b = new byte[1024];
            Array.Clear(b, 0, b.Length);
            cs.Receive(b);
            msg = Encoding.ASCII.GetString(b).TrimEnd('\0');
            Console.WriteLine("[+] Received from server: {0}", msg);
            cs.Close();
            Console.ReadKey();
        }
    }
}
