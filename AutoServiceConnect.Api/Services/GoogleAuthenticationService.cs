using System.Security.Authentication;
using AutoServiceConnect.Api.Database;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services.Models;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Services;

public class GoogleAuthenticationService
{
    private readonly AppSettings _appSettings;
    private readonly AutoServiceDbContext _autoServiceDbContext;

    public GoogleAuthenticationService(AppSettings appSettings, AutoServiceDbContext autoServiceDbContext)
    {
        _appSettings = appSettings;
        _autoServiceDbContext = autoServiceDbContext;
    }
    
    public async Task<string> VerifyToken(string code)
    {
        var credential = new GoogleAuthorizationCodeFlow
        (
            new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = _appSettings.GoogleCredentials.ClientId,
                    ClientSecret = _appSettings.GoogleCredentials.ClientSecret
                },
                Scopes = new List<string>
                {
                    "https://www.googleapis.com/auth/userinfo.profile",
                    "https://www.googleapis.com/auth/userinfo.email"
                }
            }
        );
        
        var token = await credential.ExchangeCodeForTokenAsync("", code, "http://localhost:3000", CancellationToken.None);
        
        var payload = await GoogleJsonWebSignature.ValidateAsync(token.IdToken);
        return payload.Email;
    }
    
    public async Task<GoogleTokenResponse> Authenticate(string authCode)
    {
        var googleUserEmail = await VerifyToken(authCode);

        var dbUser = await _autoServiceDbContext.Users.FirstOrDefaultAsync(u =>
            u.Email == googleUserEmail);
        
        switch (dbUser)
        {
            case null: dbUser = _autoServiceDbContext.Users.Add(new User
                {
                    Email = googleUserEmail,
                }).Entity;
                break;
            //
            // case {IsGoogleAccount: true}: _autoServiceDbContext.Users.Update(dbUser);
            //     dbUser.FirstName = googleUserInfo.FirstName; // Update properties in database from google acc
            //     dbUser.LastName = googleUserInfo.LastName;
            //     dbUser.ImageFileName = googleUserInfo.ImageFileName;
            //     break;
            
            case {IsGoogleAccount: false}: throw new AuthenticationException("You already have an account ");
        }

        await _autoServiceDbContext.SaveChangesAsync();
        
        var token = Helpers.AccountHelpers.GenerateToken(_appSettings.JwtSecret, _appSettings.JwtExpiryDays,
            dbUser.Id.ToString());

        return new GoogleTokenResponse { Token = token, Email = dbUser.Email};
    }
}