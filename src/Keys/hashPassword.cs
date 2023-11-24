public class PasswordHashing
{
    public static string HashPassword(string plainPassword)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, salt);

        return hashedPassword;
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        bool isMatch = BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);

        return isMatch;
    }
}
