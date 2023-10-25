using System.Drawing;
using CarrierPidgeon.Middleware;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Algorithms{
    public class Dijkstra{

        private readonly List<Node> nodes; 

        public Dijkstra(List<Node> nodes){
            this.nodes = nodes;
        }

        public List<Point> CalculatePath(Node end)
        {
            List<Node> _clearNodes = nodes.Select(n => NodeMiddleware.CloneNode(n)).ToList();
            _clearNodes.FirstOrDefault(n => n.cords == end.cords).properties.Add("end");

            List<Node> openNodes = _clearNodes.OrderBy(n => n.gCost).ToList();
            Node start = openNodes.First();
            while(openNodes.Any())
            {
                Node currentNode = openNodes.First();
                openNodes.Remove(currentNode);
                if(currentNode.properties.Contains("end")){
                    break;
                }

            // Logic

            }

            List<Point> shortestPath = new List<Point>();
            
            if(end != null)
            {
                shortestPath.AddRange(end.origin);
                shortestPath.Add(end.cords);
            }

            return shortestPath;
        }
    }
}
