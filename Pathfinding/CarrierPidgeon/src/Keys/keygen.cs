using System.Security.Cryptography;

namespace CarrierPidgeon.Keys{
    public class Keygen{
        public static string GenerateRandomKey(int keyLenghtInBytes)
        {
            byte[] keyBytes = new byte[keyLenghtInBytes];

            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }
    }
}