using AutoServiceConnect.Api.Database.Models;

namespace AutoServiceConnect.Api.ViewModels;

public class LoginUserResponse
{
    public string Email { get; set; }
    public string Token { get; set; }
    public Role Role { get; set; }
}