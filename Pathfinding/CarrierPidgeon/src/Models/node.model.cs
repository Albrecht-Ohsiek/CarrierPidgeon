using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.Json.Serialization;
using CarrierPidgeon.Types;

namespace CarrierPidgeon.Models
{
    public class Node : INode
    {
        [Required]
        public Point cords {get; set;}
        [Required]
        public bool occupied { get; set; }
        [Required]
        public bool accessible { get; set; }
        public int gCost { get; set; }
        public int hCost { get; set; }
        public int fCost { get; set; }
        public List<String> properties { get; set; }
        public List<Point> origin {get; set;}

        public Node()
        {

        }

        public Node(Point cords)
        {
            this.cords = cords;
            this.occupied = false;
            this.accessible = true;
            this.gCost = 0;
            this.hCost = 0;
            this.fCost = 0;
            this.properties = new List<string>();
            this.origin = new List<Point>();
        }

        [JsonConstructor]
        internal Node(Point cords, bool isOccupied, bool isAccessible, int calculatedFCost, int calculatedGCost, int calculatedHCost, List<string> properties, List<Point> origin)
        {
            this.cords = cords;
            this.occupied = isOccupied;
            this.accessible = isAccessible;
            this.fCost = calculatedFCost;
            this.gCost = calculatedGCost;
            this.hCost = calculatedHCost;
            this.properties = properties;
            this.origin = origin;
        }
    }
}