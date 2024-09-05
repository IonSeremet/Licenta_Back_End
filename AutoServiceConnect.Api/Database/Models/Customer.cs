using System.ComponentModel.DataAnnotations;

namespace AutoServiceConnect.Api.Database.Models;

public class Customer
{
    public int UserId { get; set; }
    public User User { get; set; }
    [Key]
    public int CustomerId { get; set; }

    public string? ContactInformation { get; set; }
    public ICollection<Car> OwnedCars { get; set; }
}