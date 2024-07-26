namespace AutoServiceConnect.Api;

public class AppSettings
{
    public GoogleCredentials GoogleCredentials { get; set; }
    public int JwtExpiryDays { get; set; }
    public string JwtSecret { get; set; }
    public string SqlConnectionString { get; set; }
}

public class GoogleCredentials
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}