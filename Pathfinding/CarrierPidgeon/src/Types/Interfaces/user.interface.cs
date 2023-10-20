using MongoDB.Bson;

namespace CarrierPidgeon.Types{
    interface IUser{
        ObjectId _id {get; set;}
        string name {get; set;}
        string email {get; set;}
        string password {get; set;}
    }
}