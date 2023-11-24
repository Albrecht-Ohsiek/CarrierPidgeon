using System.Drawing;

namespace CarrierPidgeon.Models
{
    public class RouteResponse
    {
        public string _id {get; set;}
        public string status {get; set;}
        public List<Point> path {get; set;}

        // Default constructor
        public RouteResponse()
        {
        }

        // Parameterized constructor
        public RouteResponse(string routeId, string status, List<Point> path)
        {
            this._id = routeId;
            this.status = status;
            this.path = path;
        }
    }
}