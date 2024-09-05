namespace AutoServiceConnect.Api.Database.Models;

public class Car
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Owner { get; set; }
    public string? Brand { get; set; }
    public string Model { get; set; }
    public string? Year { get; set; }
    public string? VIN { get; set; }
    public string LicencePlace { get; set; }
    public int? Mileage { get; set; }
    public string? Color { get; set; }
    public string? EngineType { get; set; }
    public int? Rating { get; set; }
    public string? ImgUrl { get; set; }
    public string? Speed { get; set; }
    public bool? HasGps { get; set; }
    public string? SeatType { get; set; }
    public string? Automatic { get; set; }
    public string? Description { get; set; }
}