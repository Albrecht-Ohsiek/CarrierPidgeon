namespace AStart_Algorithm
{
    public interface INode
    {
        int posX{ get; set; }
        int posY{ get; set; }
        int gCost { get; set; }
        int hCost { get; set; }
        int fCost { get; set; }
        bool accessible { get; set; }
        bool occupied { get; set; }
        List<Enum> properties { get; set; }
        List<Node>? origin{ get; set; }
    }
}