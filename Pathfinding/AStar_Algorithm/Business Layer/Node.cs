using System.Collections.Generic;

public class Node : INode
{
    private bool isOccupied;
    private bool isAccessible;
    private int calculatedFCost;
    private int calculatedGCost;
    private int calculatedHCost;
    private string properties;

    public Node(){
       this.isOccupied = false;
        this.isAccessible = true;
        this.calculatedGCost = 0;
        this.calculatedHCost = 0;
        this.calculatedFCost = 0;
        this.properties = "";
    }

    public Node(bool isOccupied, bool isAccessible, int calculatedFCost, int calculatedGCost, int calculatedHCost, string properties){
        this.isOccupied=isOccupied;
        this.isAccessible=isAccessible;
        this.calculatedFCost=calculatedFCost;
        this.calculatedGCost=calculatedGCost;
        this.calculatedHCost=calculatedHCost;
        this.properties = properties;
    }

    public static Node[,] initNodes(int width, int bredth)
    {
        Node[,] nodes = new Node[width,bredth];
        for(int i=0; i < width; i++)
            for(int j=0; j < bredth; j++)
            {
                nodes[i,j] = new Node();
            }

        return nodes;
    }

    public bool accessible()
    {
        return isAccessible;
    }

    public int fCost()
    {
        return calculatedFCost;
    }

    public int gCost()
    {
        return calculatedGCost;
    }

    public int hCost()
    {
        return calculatedHCost;
    }

    public string nodeProperties()
    {
        return properties;
    }

    public bool occupied()
    {
        return isOccupied;
    }
}