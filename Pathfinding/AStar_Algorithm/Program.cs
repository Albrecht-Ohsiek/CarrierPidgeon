﻿using System;

namespace AStart_Algorithm
{
    class Program
    {

        static void Main(string[] args)
        {

            // Initialise Map Mesh
            Node[,] nodes = Node.initNodes(5, 5);
            nodes[1, 4] = Node.placeObstacle(nodes[1, 4]);
            nodes[4, 1] = Node.placeObstacle(nodes[4, 1]);

            nodes[2, 3] = Node.setStart(nodes, nodes[2, 3]);
            nodes[0, 0] = Node.setEnd(nodes, nodes[0, 0]);

            Display_Console.Display(nodes);

        }
    }

}