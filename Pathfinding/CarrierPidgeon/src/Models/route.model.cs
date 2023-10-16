using CarrierPidgeon.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarrierPidgeon.Models
{
    public class Route : IRoute
    {
        [BsonId]
        public ObjectId _id {get; set;}
        public ObjectId droneId {get; set;}
        public string status {get; set;}
        public List<Node> path {get; set;}
    }
}