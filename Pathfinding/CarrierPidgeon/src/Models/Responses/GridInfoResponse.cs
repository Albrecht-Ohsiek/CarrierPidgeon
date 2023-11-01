using System.Drawing;

namespace CarrierPidgeon.Models
{
    public class GridInfoResponse
    {
        public Point cords {get; set;}
        public bool occupied { get; set; }
        public bool accessible { get; set; }
        public List<String> properties { get; set; }
    }
}