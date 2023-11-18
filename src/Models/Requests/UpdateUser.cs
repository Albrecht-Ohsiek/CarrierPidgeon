using System.ComponentModel.DataAnnotations;

namespace CarrierPidgeon.Models
{
    public class UpdateUserRequest
    {
        public string name { get; set; }
        [MinLength(8)]
        public string password {get; set;}
        public string confirmPassword {get; set;}
    }
}