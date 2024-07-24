using System.Security.Authentication;
using System.Text;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Helpers;
using AutoServiceConnect.Api.Utils;
using AutoServiceConnect.Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Services;

public class UserService
{
    private readonly AutoServiceDbContext _autoServiceDbContext;
    private readonly AppSettings _appSettings;
    private readonly IJwtUtils _jwtUtils;

    public UserService(
        AutoServiceDbContext autoServiceDbContext, 
        AppSettings appSettings,
        IJwtUtils jwtUtils)
    {
        _autoServiceDbContext = autoServiceDbContext;
        _appSettings = appSettings;
        _jwtUtils = jwtUtils;
    }
    
    public async Task<int> RegisterUser(string email, string password)
    {
        if (!AccountHelpers.ValidateEmail(email))
        {
            throw new ArgumentException("Email not valid", nameof(email));
        }
        if (!AccountHelpers.ValidatePassword(password))
        {
            throw new ArgumentException(
                "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.", 
                nameof(password));
        }

        if (await _autoServiceDbContext.Users.AnyAsync(u => u.Email == email))
        {
            throw new ArgumentException("User with this email already exists", nameof(email));
        }

        AccountHelpers.CreatePasswordHash(password, out byte[] passwordHash,
            out byte[] passwordSalt);

        var newUser = new User
        {
            Email = email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        _autoServiceDbContext.Users.Add(newUser);
        await _autoServiceDbContext.SaveChangesAsync();
        return newUser.Id;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _autoServiceDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<(User, string)> Login(string email, string password)
    {
        var profileFromDb = await _autoServiceDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        if (profileFromDb == null)
            throw new AuthenticationException();

        // if (profileFromDb.LockDate.HasValue &&
        //     profileFromDb.LockDate.Value < DateTime.Now.AddDays(1))// TODO: Magic number
        // {
        //     throw new DomainModelException("Account locked");
        // }

        if (!VerifyPasswordHash(password,
                profileFromDb.PasswordHash, profileFromDb.PasswordSalt))
        {
            // _profileRepository.AddAttempt(profileFromDb.Email);
            // if (profileFromDb.IncorrectAttempts >= 5)// TODO: Magic number
            // {
            //     _profileRepository.LockProfile(profileFromDb.Email);
            //     throw new DomainModelException("Account locked");
            // }
            throw new AuthenticationException();
        }

        var token = _jwtUtils.GenerateJwtToken(profileFromDb);

        return (profileFromDb, token);
    }
    
    private static bool VerifyPasswordHash(string password,
        byte[] storedHash, byte[] storedSalt)
    {
        if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
        if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedHash));

        using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (var i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != storedHash[i]) return false;
        }

        return true;
    }
}