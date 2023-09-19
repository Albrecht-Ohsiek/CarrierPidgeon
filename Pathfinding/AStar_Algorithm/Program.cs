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
            nodes[3,3] = Node.placeObstacle(nodes[3,3]);
            nodes[4,3] = Node.placeObstacle(nodes[4,3]);
            //nodes[2,3] = Node.placeObstacle(nodes[2,3]);
            nodes[2,2] = Node.placeObstacle(nodes[2,2]);
            nodes[1,2] = Node.placeObstacle(nodes[1,2]);
            nodes[1,3] = Node.placeObstacle(nodes[1,3]);

            Node start = new Node(4,4);
            nodes[4, 4] = Node.setStart(nodes, start);
            Node end = new Node(0,0);
            nodes[0, 0] = Node.setEnd(nodes, end);

            Display_Console.Display(nodes);

            List<Node> route = Path.calculatePath(nodes, start, end);
            foreach(Node node in route){
                Console.WriteLine(node.posX + " " + node.posY);
            }
            if(route.Count > 0)
            {
                Console.WriteLine(end.posX + " " + end.posY);
            }

            //List<String> data = new List<String>();
            //while (true)
            //{
            //    Socket_Server socket_Server = new Socket_Server(IPAddress.Parse("127.0.0.1"), 8000);
            //    socket_Server.Start();
            //    TcpClient client = socket_Server.WaitForClient();
            //
            //    // saves recieved input into list
            //    data = data_processing_services.processResponseToList(socket_Server.getClientResponse(client));
            //
            //    foreach (var item in data)
            //    {
            //        Console.WriteLine(item);
            //    }
            //
            //    socket_Server.Stop();
            //}


        }
    }

}