namespace AutoServiceConnect.Api.Database.Models;

public class AutoService
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string MapCoordinates { get; set; }
    public string Rating { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}