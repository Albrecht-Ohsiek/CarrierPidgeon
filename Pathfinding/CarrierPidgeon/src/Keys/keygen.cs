using System.Security.Cryptography;

namespace CarrierPidgeon.Keys
{
    public class Keygen
    {
        public static void GenerateKeyPair(out string publicKey, out string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(4096)) // You can adjust the key size
            {
                privateKey = rsa.ToXmlString(true); // Get the private key
                publicKey = rsa.ToXmlString(false); // Get the public key
            }
        }

        public static string GenerateRandomKey(int keySize)
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[keySize / 8];
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}