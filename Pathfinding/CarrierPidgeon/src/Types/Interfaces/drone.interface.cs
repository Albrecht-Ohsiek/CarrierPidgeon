using MongoDB.Bson;

namespace CarrierPidgeon.Types
{
    public interface IDrone
    {
        ObjectId _id {get; set;}
        string userId{ get; set;}
        string status {get; set;}
        string? routeId {get; set;}
    }
}