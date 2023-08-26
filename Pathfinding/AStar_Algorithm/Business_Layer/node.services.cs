using System.Collections.Generic;
using AStart_Algorithm.Business_Layer;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AStart_Algorithm
{
    public class node_services
    {
        public static Node[,] initNodes(int width, int bredth)
        {
            Node[,] nodes = new Node[width, bredth];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < bredth; j++)
                {
                    nodes[i, j] = new Node();
                }

            return nodes;
        }

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
                else {
                    throw new Exception("Unable to assign unique property");
                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return node;
            }

        }

    }

}