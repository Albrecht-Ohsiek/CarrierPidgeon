using System.Drawing;

namespace CarrierPidgeon.Models.Factories
{
    public class NodeFactory
    {
        private List<Node> nodes;

        public NodeFactory(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        public void CreateObstacleNode(Point cords)
        {
            Node node = nodes.FirstOrDefault(n => n.cords == cords);
            if (node != null)
            {
                if (node.accessible)
                {
                    node.occupied = true;
                    node.accessible = false;
                    node.properties.Clear();
                    node.properties.Add("obstacle");
                }
                else
                {
                    Console.Error.WriteLine("Node is not accessible");
                }
            }
            else
            {
                Console.Error.WriteLine("Node does not exist");
            }
        }

        public void CreateStartNode(Point cords)
        {
            Node node = nodes.FirstOrDefault(n => n.cords == cords);
            if (node != null)
            {
                if (nodes.Any(n => n.properties.Contains("start")))
                {
                    Console.Error.WriteLine("Another node already has the 'start' property");
                }
                node.properties.Add("start");
            }
            else
            {
                Console.Error.WriteLine("Node does not exist");
            }
        }

        public void CreateEndNode(Point cords)
        {
            Node node = nodes.FirstOrDefault(n => n.cords == cords);
            if (node != null)
            {
                node.properties.Add("end");
            }
            else
            {
                Console.Error.WriteLine("Node does not exist");
            }
        }
    }
}