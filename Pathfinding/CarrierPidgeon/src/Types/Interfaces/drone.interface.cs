using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IDrone
    {
        ObjectId _id {get; set;}
        string status {get; set;}
        Models.Route activeRoute {get; set;}
    }
}