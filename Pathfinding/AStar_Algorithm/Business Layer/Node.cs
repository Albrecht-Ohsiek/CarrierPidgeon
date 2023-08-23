using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_Algorithm.Business_Layer
{
    internal class Node : INode
    {
        public Node(int start, int end, bool accessible) {
        
        }

        public bool accessible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double gCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double hCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double fCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
