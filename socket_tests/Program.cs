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

            string inputData = "init grid 10 10\nadd o 2 2\nadd o 5 5\nadd s 1 1\nadd o 8 8";
            //string inputData = "add e 3 4";

            byte[] requestData = Encoding.ASCII.GetBytes(inputData);
            stream.Write(requestData, 0, requestData.Length);

            byte[] responseBytes = new byte[1024];
            int bytesRead = stream.Read(responseBytes, 0, responseBytes.Length);
            string response = Encoding.ASCII.GetString(responseBytes, 0, bytesRead);
            Console.WriteLine("Server response: " + response);

            stream.Close();
            client.Close();
        }
    }
}