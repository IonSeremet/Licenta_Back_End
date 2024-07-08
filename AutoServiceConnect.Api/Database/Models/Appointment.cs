namespace AutoServiceConnect.Api.Database.Models;

public class Appointment
{
    public int Id { get; set; }
    public int AutoServiceId { get; set; }
    public AutoService AutoService { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
}