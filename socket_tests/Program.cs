using System;
using System.Net.Sockets;
using System.Text;

namespace socket_tests
{
    class Program
    {

        static void Main(string[] args)
        {
            string serverIp = "127.0.0.1"; // Replace with your server's IP address
            int serverPort = 8000; // Replace with your server's port

            TcpClient client = new TcpClient();
            client.Connect(serverIp, serverPort);

            NetworkStream stream = client.GetStream();

            string requestData = "Hello, server!"; // Your request data
            byte[] data = Encoding.ASCII.GetBytes(requestData);

            stream.Write(data, 0, data.Length);

            // Receive response (for simplicity, we'll just print it)
            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string response = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
            Console.WriteLine("Server response: " + response);

            stream.Close();
            client.Close();
        }
    }
}