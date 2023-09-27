using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models
{
    public class Drone_Model : IDrone
    {
        public ObjectId droneId { get; set; }
        public string status { get; set; }
        public Route_Model activeRoute {get; set;}

        public Drone_Model(){

        }

        public Drone_Model(ObjectId droneId, string status, Route_Model activeRoute){
            this.droneId = droneId;
            this.status = status;
            this.activeRoute = activeRoute;
        }
    }
}