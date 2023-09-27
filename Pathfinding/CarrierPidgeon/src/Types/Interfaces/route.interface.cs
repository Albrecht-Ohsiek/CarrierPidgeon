using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    interface IRoute
    {
        ObjectId routeId {get; set;}
        ObjectId droneId {get; set;}
        string status {get; set;}
        List<Node> path {get; set;}
    }
}