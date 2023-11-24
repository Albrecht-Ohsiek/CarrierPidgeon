namespace CarrierPidgeon.Models
{
    public class DroneResponse
    {
        public string _id { get; set; }
        public string userId {get; set;}
        public string status { get; set; }
        public string? routeId {get; set;}

        public DroneResponse(){

        }

        public DroneResponse(string droneId, string userId, string status, string routeId){
            this._id = droneId;
            this.userId = userId;
            this.status = status;
            this.routeId = routeId;
        }
    }
}