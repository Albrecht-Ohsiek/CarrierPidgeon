using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models
{
    public class DroneModel : IDrone
    {
        public ObjectId droneId { get; set; }
        public string status { get; set; }
        public RouteModel activeRoute {get; set;}

        public DroneModel(){

        }

        public DroneModel(ObjectId droneId, string status, RouteModel activeRoute){
            this.droneId = droneId;
            this.status = status;
            this.activeRoute = activeRoute;
        }
    }
}