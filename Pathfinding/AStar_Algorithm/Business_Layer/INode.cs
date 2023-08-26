using System.Collections.Generic;

namespace AStart_Algorithm
{
    public interface INode
    {
        int gCost { get; set; }
        int hCost { get; set; }
        int fCost { get; set; }
        bool accessible { get; set; }
        bool occupied { get; set; }
        List<Enum> properties { get; set; }

    }
}