using System.ComponentModel.DataAnnotations;

namespace CarrierPidgeon.Models
{
    public class LoginRequest
    {
        [Required]
        public string name { get; set; }
        
        [Required]
        [MinLength(8)]
        public string password {get; set;}
    }
}