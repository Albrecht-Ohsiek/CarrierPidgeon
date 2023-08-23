using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Algorithm.Business_Layer
{
    internal interface INode
    {
        // Control
        bool accessible { get; set; }

        // Distance
        double gCost { get; set; }
        double hCost { get; set; }
        double fCost { get; set; }


    }
}
