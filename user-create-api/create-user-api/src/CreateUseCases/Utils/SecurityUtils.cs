namespace CreateController.Utils;
using BCrypt.Net;


public static class SecurityUtils
{
    public static string HashPassword(string password)
    {
        return BCrypt.HashPassword(password, 10);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Verify(password, storedHash);
    }
}