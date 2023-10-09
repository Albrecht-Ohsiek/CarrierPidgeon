using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IRoute
    {
        ObjectId routeId {get; set;}
        ObjectId droneId {get; set;}
        string status {get; set;}
        List<Node> path {get; set;}
    }
}