namespace CarrierPidgeon.Models{
    public class AuthenticationConfiguration{
        public string JwtSecret {get; set;}
        public string JwtIssuer {get; set;}
        public string JwtAudience {get; set;}
        public int JwtLifetime {get; set;}
    }
}