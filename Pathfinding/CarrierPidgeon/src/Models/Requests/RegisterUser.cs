using System.ComponentModel.DataAnnotations;

namespace CarrierPidgeon.Models
{
    public class RegisterRequest
    {
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        public string password {get; set;}
        [Required]
        public string confirmPassword {get; set;}
    }
}