using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models
{
    public class Drone : IDrone
    {
        public ObjectId droneId { get; set; }
        public string status { get; set; }
        public Route activeRoute {get; set;}

        public Drone(){

        }

        public Drone(ObjectId droneId, string status, Route activeRoute){
            this.droneId = droneId;
            this.status = status;
            this.activeRoute = activeRoute;
        }
    }
}