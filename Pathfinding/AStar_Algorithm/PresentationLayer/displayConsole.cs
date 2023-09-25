using AStart_Algorithm.Business_Layer;

namespace AStart_Algorithm
{
    class Display_Console
    {
        // Console Display Symbols
        private static char occupied = 'x';
        private static char accessible = '-';
        private static char notAccesible = 'y';
        private static char start = 'S';
        private static char end = '#';


        public static void Display(Node[,] nodes)
        {
            // Dimenstions of INode mesh
            int width = nodes.GetLength(0);
            int bredth = nodes.GetLength(1);

            // TODO: Implement Switch Statement
            Console.Clear();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < bredth; j++)
                {
                    if (nodes[i, j].occupied && nodes[i, j].properties.Contains(NodeProperties.Obstacle))
                    {
                        Console.Write(occupied);
                    }
                    else if (nodes[i, j].properties.Contains(UniqueNodeProperties.Start))
                    {
                        Console.Write(start);
                    }
                    else if (nodes[i, j].properties.Contains(UniqueNodeProperties.End))
                    {
                        Console.Write(end);
                    }
                    else if (nodes[i, j].accessible && !nodes[i, j].occupied)
                    {
                        Console.Write(accessible);
                    }
                    else if (!nodes[i, j].accessible)
                    {
                        Console.Write(notAccesible);
                    }
                }
                Console.Write('\n');
            }
        }
    }

}