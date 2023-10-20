using CarrierPidgeon.Types;
using CarrierPidgeon.Models;
using System.Numerics;

namespace CarrierPidgeon.Services
{
    public class NodeServices
    {
        // Create board
        public static List<Node> initNodes(int width, int bredth)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < width; i++)
                for (int j = 0; j < bredth; j++)
                {
                    nodes.Add(new Node(i, j));
                }

            return nodes;
        }

        // Calculate costs
        public static Node getNodeCosts(Node currentNode, Node startNode, Node endNode)
        {
            currentNode.gCost = calculateGCost(startNode, currentNode);
            currentNode.hCost = calculateHCost(endNode, currentNode);
            currentNode.fCost = calculateFCost(currentNode.gCost, currentNode.hCost);

            return currentNode;
        }
        
        public static int getDistance(Node node1, Node node2)
        {
            Vector2 start = new Vector2(node1.posX, node1.posY);
            Vector2 end = new Vector2(node2.posX, node2.posY);

            return (int)(Vector2.Distance(start, end) * 10);
        }

        public static int calculateGCost(Node startNode, Node currentNode)
        {
            if (currentNode.origin != null && currentNode.origin.Any())
            {
                Node previousNode = currentNode.origin.Last();
                return getDistance(previousNode, currentNode) + previousNode.gCost;
            }
            else
            {
                return getDistance(startNode, currentNode);
            }
        }

        public static int calculateHCost(Node endNode, Node currentNode)
        {
            return getDistance(endNode, currentNode);
        }

        public static int calculateFCost(int gCost, int hCost)
        {
            return gCost + hCost;
        }

        // set node properties
        public static Node setObstacle(List<Node> nodes, Node node)
        {
            return SetNodeProperty(nodes, node, NodeProperties.Obstacle);
        }

        public static Node setStart(List<Node> nodes, Node node)
        {
            return SetNodeProperty(nodes, node, UniqueNodeProperties.Start);
        }

        public static Node setEnd(List<Node> nodes, Node node)
        {
            return SetNodeProperty(nodes, node, UniqueNodeProperties.End);
        }

        public static Node SetNodeProperty(List<Node> nodes, Node node, Enum property)
        {
            try
            {
                if (Enum.IsDefined(typeof(UniqueNodeProperties), property))
                {
                    if (!uniquePropertyExists(nodes, property) && !node.properties.Contains(NodeProperties.Obstacle) && !node.properties.Any(prop => prop.GetType() == typeof(UniqueNodeProperties)))
                    {
                        node.properties.Add(property);
                        return node;
                    }
                    else
                    {
                        throw new Exception("Unable to assign unique property");
                    }
                }
                else if (property.Equals(NodeProperties.Obstacle))
                {
                    if (node.accessible)
                    {             
                        node.occupied = true;
                        node.accessible = false;
                        node.properties.RemoveAll(prop => prop.GetType().IsEnum && prop.GetType().GetEnumUnderlyingType() == typeof(UniqueNodeProperties));
                        node.properties.Add(property);
                        return node;
                    }
                }
                
                throw new Exception("Unable to assign property");

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return node;
            }
        }

        public static bool uniquePropertyExists(List<Node> nodes, Enum property)
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
                posX = node.posX,
                posY = node.posY,
                fCost = node.fCost,
                gCost = node.gCost,
                hCost = node.hCost,
                properties = new List<Enum>(node.properties),
                origin = new List<Node>(node.origin),
            };

            return newNode;
        }
    }
}
