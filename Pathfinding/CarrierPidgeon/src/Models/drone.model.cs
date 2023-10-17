using CarrierPidgeon.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarrierPidgeon.Models
{
    public class Drone : IDrone
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string userId {get; set;}
        public string status { get; set; }
        public string? routeId {get; set;}

        public Drone(){

        }

        public Drone(ObjectId droneId, string userId, string status, string routeId){
            this._id = droneId;
            this.userId = userId;
            this.status = status;
            this.routeId = routeId;
        }
    }
}