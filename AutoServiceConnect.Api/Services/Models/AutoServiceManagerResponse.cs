namespace AutoServiceConnect.Api.Services.Models;

public class LoginAutoServiceResponse
{
    public string Token { get; set; }
    public string ContactEmail { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string MapCoordinates { get; set; }
}