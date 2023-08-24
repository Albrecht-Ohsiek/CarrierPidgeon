using System.Collections.Generic;

class Display_Console{
    // Console Display Symbols
    private static char occupied = 'x';
    private static char accessible = '-';
    private static char notAccesible = 'x';
    private static char start = 'S';
    private static char end = '#';
    

    public static void Display(Node[,] nodes)
    {   
        // Dimenstions of INode mesh
        int width = nodes.GetLength(0);
        int bredth = nodes.GetLength(1);

        Console.WriteLine("", width, bredth);

        for (int i = 0; i < width; i++)
            for (int j = 0; j < bredth; j++)
            {
                if (!nodes[i, j].accessible())
                {
                    Console.Write(notAccesible);
                }
                else if(nodes[i, j].accessible() && !nodes[i, j].occupied())
                {
                    Console.Write(accessible);
                }
                else if (nodes[i, j].occupied())
                {
                    Console.Write(occupied);
                }
                else if (nodes[i,j].nodeProperties().ToLower() == "start")
                {
                    Console.Write(start);
                }
                else if(nodes[i,j].nodeProperties().ToLower() == "end")
                {
                    Console.Write(end);
                }
            }
        Console.WriteLine("");
    }
}