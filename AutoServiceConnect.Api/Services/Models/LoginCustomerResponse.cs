namespace AutoServiceConnect.Api.Services.Models;

public class LoginCustomerResponse
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string? Name { get; set; }
    public string? ContactInformation { get; set; }
    public string? ProfilePicture { get; set; }
}