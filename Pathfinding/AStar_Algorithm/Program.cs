using System.Net;
using System.Net.Sockets;

namespace AStart_Algorithm
{
    class Program
    {

        static void Main(string[] args)
        {

            // Initialise Map Mesh -- temp
            Node[,] nodes = Node.initNodes(5, 5);
            nodes[1, 4] = Node.placeObstacle(nodes[1, 4]);
            nodes[4, 1] = Node.placeObstacle(nodes[4, 1]);

            nodes[2, 3] = Node.setStart(nodes, nodes[2, 3]);
            nodes[0, 0] = Node.setEnd(nodes, nodes[0, 0]);

            Display_Console.Display(nodes);

            // List<Node> route = Path.calculatePath(nodes, nodes[2, 3], nodes[0, 0]);
            // foreach(Node node in route){
            //     Console.WriteLine(node.posX + " " + node.posY);
            // }

            List<String> data = new List<String>();
            while (true)
            {
                Socket_Server socket_Server = new Socket_Server(IPAddress.Parse("127.0.0.1"), 8000);
                socket_Server.Start();
                TcpClient client = socket_Server.WaitForClient();

                // saves recieved input into list
                data = data_processing_services.processResponseToList(socket_Server.getClientResponse(client));

                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }

                socket_Server.Stop();
            }


        }
    }

}