using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AStart_Algorithm
{
    public class Socket_Server
    {
        private TcpListener server;

        public void Start()
        {
            IPAddress serverAddress = IPAddress.Parse("127.0.0.1");
            int serverPort = 8000;

            server = new TcpListener(serverAddress, serverPort);

            try
            {
                server.Start();
                Console.WriteLine("A* Algorithm Server listening on port " + serverPort);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

        }

        public void Stop()
        {
            try{
                server.Stop();
                Console.WriteLine("A* Algorithm Server stopped succsesfully");
            }
            catch(Exception e)
            {
               Console.Error.WriteLine(e.Message);
            }
        }

        public TcpClient WaitForClient()
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected: " + ((IPEndPoint)client.Client.RemoteEndPoint).Address);
            return client;
        }

        public void processClient(TcpClient client)
        {
            NetworkStream networkStream = client.GetStream();
            byte[] data = new byte[1024];
            int bytes_read = networkStream.Read(data, 0, data.Length);
            String received_data = Encoding.ASCII.GetString(data, 0, bytes_read);

            networkStream.Close();
        }

    }
}