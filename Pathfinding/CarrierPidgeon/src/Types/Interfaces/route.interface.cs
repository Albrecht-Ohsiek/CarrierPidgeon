using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IRoute
    {
        ObjectId _id {get; set;}
        string droneId {get; set;}
        string status {get; set;}
        List<Node> path {get; set;}
    }
}