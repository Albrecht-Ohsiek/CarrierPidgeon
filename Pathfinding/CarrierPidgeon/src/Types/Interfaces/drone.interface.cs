using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IDrone
    {
        ObjectId droneId {get; set;}
        string status {get; set;}
        Models.Route activeRoute {get; set;}
    }
}