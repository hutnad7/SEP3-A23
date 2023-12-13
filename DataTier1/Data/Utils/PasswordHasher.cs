namespace Service.Utils;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with the salt
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        // Combine the salt and the hash
        string saltString = Convert.ToBase64String(salt);
        return $"{saltString}:{hashed}";
    }

    public static bool VerifyPassword(string hashedPassword, string password)
    {
        // Extract salt from the stored hash
        var parts = hashedPassword.Split(':');
        if (parts.Length != 2)
        {
            throw new FormatException("Invalid hash format.");
        }

        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = parts[1];

        // Hash the input password with the extracted salt
        string computedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        // Compare the computed hash with the stored hash
        return storedHash == computedHash;
    }
}
