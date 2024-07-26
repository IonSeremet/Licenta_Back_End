namespace AutoServiceConnect.Api.Database.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string? FullName { get; set; }
    public string? ProfilePicture { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool IsGoogleAccount { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public Role Role { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int? ServiceManagerId { get; set; }
    public AutoServiceManager? ServiceManager { get; set; }
}