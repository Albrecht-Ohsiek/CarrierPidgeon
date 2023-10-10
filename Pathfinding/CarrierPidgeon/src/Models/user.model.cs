using CarrierPidgeon.Types;
using MongoDB.Bson;

namespace CarrierPidgeon.Models{
    public class User : IUser
    {
        public ObjectId userId { get; set;}
        public string name { get; set; }
        public string email { get; set; }
        public string password {get; set;}

        public User(ObjectId userId, string name, string email, string password)
        {
            this.userId = userId;
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}