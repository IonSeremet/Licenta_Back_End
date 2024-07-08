namespace AutoServiceConnect.Api.Database.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool IsGoogleAccount { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public Role Role { get; set; }
}