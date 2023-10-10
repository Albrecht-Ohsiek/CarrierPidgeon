using MongoDB.Bson;

namespace CarrierPidgeon.Types{
    interface IUser{
        ObjectId userId {get; set;}
        string name {get; set;}
        string email {get; set;}
        string password {get; set;}
    }
}