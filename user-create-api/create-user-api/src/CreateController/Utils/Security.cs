namespace CreateController.Utils;
using BCrypt.Net;


public static class Security
{
    public static string HashPassword(string password)
    {
        return BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Verify(password, storedHash);
    }
}