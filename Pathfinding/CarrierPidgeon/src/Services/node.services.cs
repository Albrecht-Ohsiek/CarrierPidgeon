using CarrierPidgeon.Models;
using System.Numerics;
using System.Drawing;
using CarrierPidgeon.Models.Factories;

namespace CarrierPidgeon.Services
{
    public class NodeServices
    {
        private List<Node> nodes;
        private NodeFactory nodeFactory;

        public NodeServices(List<Node> nodes)
        {
            this.nodes = nodes;
            nodeFactory = new NodeFactory(nodes);
        }

        // Create board
        public static List<Node> initNodes(int width, int bredth)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < width; i++)
                for (int j = 0; j < bredth; j++)
                {
                    Point point = new Point(i, j);
                    nodes.Add(new Node(point));
                }

            return nodes;
        }

        // Calculate costs
        public static Node getNodeCosts(Node currentNode, Point startNode, Point endNode, List<Node> nodes)
        {
            currentNode.gCost = calculateGCost(startNode, currentNode.cords, nodes);
            currentNode.hCost = calculateHCost(endNode, currentNode.cords);
            currentNode.fCost = calculateFCost(currentNode.gCost, currentNode.hCost);

            return currentNode;
        }

        public static int getDistance(Point node1, Point node2)
        {
            Vector2 start = new Vector2(node1.X, node1.Y);
            Vector2 end = new Vector2(node2.X, node2.Y);

            return (int)(Vector2.Distance(start, end) * 10);
        }

        public static int calculateGCost(Point startNode, Point currentNode, List<Node> nodes)
        {
            Node currentNodeInfo = nodes.Find(node => node.cords == currentNode);

            if (currentNodeInfo.origin != null && currentNodeInfo.origin.Count > 0)
            {
                Point previousNodeCords = currentNodeInfo.origin.Last();
                Node previousNode = nodes.Find(node => node.cords == previousNodeCords);
                return getDistance(previousNodeCords, currentNode) + previousNode.gCost;
            }
            else
            {
                return getDistance(startNode, currentNode);
            }
        }

        public static int calculateHCost(Point endNode, Point currentNode)
        {
            return getDistance(endNode, currentNode);
        }

        public static int calculateFCost(int gCost, int hCost)
        {
            return gCost + hCost;
        }

        // set node properties
        public void setObstacle(Node node)
        {
            nodeFactory.CreateObstacleNode(node.cords);
        }

        public void setStart(Node node)
        {
            nodeFactory.CreateStartNode(node.cords);
        }

        public void setEnd(Node node)
        {
            nodeFactory.CreateEndNode(node.cords);
        }

        public static bool uniquePropertyExists(List<Node> nodes, string property)
        {
            foreach (Node item in nodes)
            {
                if (item.properties.Contains(property))
                {
                    return true;
                }
            }
            return false;
        }

        public static Node CloneNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            Node newNode = new Node
            {
                cords = node.cords,
                fCost = node.fCost,
                gCost = node.gCost,
                hCost = node.hCost,
                properties = new List<string>(node.properties),
                origin = new List<Point>(node.origin),
            };

            return newNode;
        }
    }
}
