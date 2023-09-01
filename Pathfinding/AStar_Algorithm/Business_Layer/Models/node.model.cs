using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AStart_Algorithm
{
    public class Node : INode
    {
        public int posX{get; set;}
        public int posY{get; set;}
        public bool occupied { get; set; }
        public bool accessible { get; set; }
        public int fCost { get; set; }
        public int gCost { get; set; }
        public int hCost { get; set; }
        public List<Enum> properties { get; set; }
        public List<Node>? origin { get; set; }

        public Node(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.occupied = false;
            this.accessible = true;
            this.gCost = 0;
            this.hCost = 0;
            this.fCost = 0;
            this.properties = new List<Enum>();
        }

        public Node(bool isOccupied, bool isAccessible, int calculatedFCost, int calculatedGCost, int calculatedHCost, List<Enum> properties)
        {
            this.posX = posX;
            this.posY = posY;
            this.occupied = isOccupied;
            this.accessible = isAccessible;
            this.fCost = calculatedFCost;
            this.gCost = calculatedGCost;
            this.hCost = calculatedHCost;
            this.properties = properties;
        }

        public static Node[,] initNodes(int x, int y)
        {
            return node_services.initNodes(x, y);
        }

        public static Node placeObstacle(Node node)
        {
            return node_services.placeObstacle(node);
        }

        public static Node setStart(Node[,] nodes, Node node)
        {
            return  node_services.setStart(nodes, node);
        }

        public static Node setEnd(Node[,] nodes, Node node)
        {
            return node_services.setEnd(nodes, node);
        }

    }

}