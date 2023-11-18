using System.Drawing;

namespace CarrierPidgeon.Models
{
    public class AddRouteRequest
    {
        public string status {get; set;}
        public List<Point> path {get; set;}
    }
}