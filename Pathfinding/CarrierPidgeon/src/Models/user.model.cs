using CarrierPidgeon.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarrierPidgeon.Models{
    public class User : IUser
    {
        [BsonId]
        public ObjectId _id { get; set;}
        public string name { get; set; }
        public string email { get; set; }
        public string password {get; set;}
    }
}