using System;

class Program{

    static void Main(string[] args){
        
        // Initialise Map Mesh
        Node[,] nodes = Node.initNodes(5,5);

        Display_Console.Display(nodes);

    } 
}