using AStart_Algorithm.Business_Layer;
using System.Numerics;
using System.Drawing;

namespace AStart_Algorithm
{
    public class node_services
    {
        // Create board
        public static Node[,] initNodes(int width, int bredth)
        {
            Node[,] nodes = new Node[width, bredth];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < bredth; j++)
                {
                    nodes[i, j] = new Node(i, j);
                }

            return nodes;
        }

        // Calculate costs
        public static int getDistance(Node node1, Node node2)
        {
            Vector2 start = new Vector2(node1.posX, node1.posY);
            Vector2 end = new Vector2(node2.posX, node2.posY);

            return (int)(Vector2.Distance(start, end) * 10);
        }

        public static int calculateGCost(Node startNode, Node currentNode)
        {
            if (currentNode.origin != null)
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

        public static Node getNodeCosts(Node currentNode, Node startNode, Node endNode)
        {
            currentNode.gCost = calculateGCost(startNode, currentNode);
            currentNode.hCost = calculateHCost(endNode, currentNode);
            currentNode.fCost = calculateFCost(startNode.gCost, startNode.hCost);

            return currentNode;
        }

        // set node properties
        public static Node placeObstacle(Node node)
        {
            try
            {
                if (node.accessible)
                {
                    node.occupied = true;
                    node.properties.Add(node_properties.Obstacle);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            return node;
        }

        public static Node setStart(Node[,] nodes, Node node)
        {
            return setUniqueProperty(nodes, node, unique_node_properties.Start);
        }

        public static Node setEnd(Node[,] nodes, Node node)
        {
            return setUniqueProperty(nodes, node, unique_node_properties.End);
        }

        public static Node setUniqueProperty(Node[,] nodes, Node node, Enum unique)
        {
            try
            {
                foreach (Node item in nodes)
                {
                    if (item.properties.Contains(unique))
                    {
                        throw new Exception("The Unique property already exists");
                    }
                }

                if (!node.properties.Contains(node_properties.Obstacle) && !node.properties.Any(prop => prop.GetType() == typeof(unique_node_properties)))
                {
                    node.properties.Add(unique);
                    return node;
                }
                else
                {
                    throw new Exception("Unable to assign unique property");
                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return node;
            }

        }
        
        public static Point getStartCordinates(Node[,] nodes)
        {
            try
            {
                foreach (Node node in nodes)
                {
                    if (node.properties.Contains(unique_node_properties.Start)) ;
                    {
                        Point cordinates = new Point(node.posX, node.posY);
                        return cordinates;
                    }
                }
                throw new Exception("Start Node does not Exist");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return new Point();
            }
        }

        public static Point getEndCordinates(Node[,] nodes)
        {
            try
            {
                foreach (Node node in nodes)
                {
                    if (node.properties.Contains(unique_node_properties.End)) ;
                    {
                        Point cordinates = new Point(node.posX, node.posY);
                        return cordinates;
                    }
                }
                throw new Exception("End Node does not Exist");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return new Point();
            }
        }


    }

}