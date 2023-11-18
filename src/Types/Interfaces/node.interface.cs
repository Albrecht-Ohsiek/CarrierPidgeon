using System.Drawing;

namespace CarrierPidgeon.Types
{
    public interface INode
    {
        Point cords {get; set;}
        int gCost { get; set; }
        int hCost { get; set; }
        int fCost { get; set; }
        bool accessible { get; set; }
        bool occupied { get; set; }
        List<string> properties { get; set; }
        List<Point> origin{ get; set; }
    }
}