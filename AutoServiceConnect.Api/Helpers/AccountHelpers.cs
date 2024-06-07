using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Regex = System.Text.RegularExpressions.Regex;

namespace AutoServiceConnect.Api.Helpers;

public static class AccountHelpers
{
    public static void CreatePasswordHash(string password,
        out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash =
            hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, Constants.Regex.Email);
    }
    
    public static bool ValidatePassword(string password)
    {
        return Regex.IsMatch(password, Constants.Regex.Password);
    }

    public static string GenerateToken(string jwtSecret, int jwtExpiryDays, string profileId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("UserId", profileId),
            }),
            Expires = DateTime.UtcNow.AddDays(jwtExpiryDays),
            SigningCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
    }
}