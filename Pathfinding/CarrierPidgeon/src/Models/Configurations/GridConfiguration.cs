using System.Drawing;

namespace CarrierPidgeon.Models{
    public class GridConfiguration{
        public int width {get; set;}
        public int height {get; set;}
        public Point start {get; set;}
        public List<Point>? obstacles {get; set;}
    }
}