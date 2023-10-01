using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    interface IDrone
    {
        ObjectId droneId {get; set;}
        string status {get; set;}
        RouteModel activeRoute {get; set;}
    }
}