namespace CarrierPidgeon.Models{
    public class UserResponse
    {
       
        public string _id { get; set;}
        public string name { get; set; }
        public string email { get; set; }
        public string password {get; set;}

        // Default constructor
        public UserResponse()
        {
        }

        // Parameterized constructor
        public UserResponse(string userId, string name, string email, string password)
        {
            this._id = userId;
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}