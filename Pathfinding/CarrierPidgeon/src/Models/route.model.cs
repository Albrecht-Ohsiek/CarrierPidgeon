using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models
{
    public class Route : IRoute
    {
        public ObjectId routeId {get; set;}
        public ObjectId droneId {get; set;}
        public string status {get; set;}
        public List<Node> path {get; set;}
    }
}