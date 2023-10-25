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

        // Calculate costs
        public static Node getNodeCosts(Node currentNode, Point startNode, Point endNode, List<Node> nodes)
        {
            currentNode.gCost = calculateGCost(startNode, currentNode, nodes);
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

        public static int calculateGCost(Point startNode, Node currentNode, List<Node> nodes)
        {
            if (currentNode.origin != null && currentNode.origin.Count > 0)
            {
                Point previousNodeCords = currentNode.origin.Last();
                Node previousNode = nodes.Find(node => node.cords == previousNodeCords);
                return getDistance(previousNodeCords, currentNode.cords) + previousNode.gCost;
            }
            else
            {
                return getDistance(startNode, currentNode.cords);
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

        // Starting Distance from nodes regardless of path taken
        public static void CalculateAllGCosts (Point start, List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                node.gCost = getDistance(start, node.cords);
            }
        }

        // set node properties
        public void setObstacle(Point node)
        {
            nodeFactory.CreateObstacleNode(node);
        }

        public void setStart(Point node)
        {
            nodeFactory.CreateStartNode(node);
            CalculateAllGCosts(node, nodes);
        }

        public void setEnd(Point node)
        {
            nodeFactory.CreateEndNode(node);
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
