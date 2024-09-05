using System.ComponentModel.DataAnnotations;

namespace AutoServiceConnect.Api.Database.Models;

public class AutoServiceManager
{
    public int UserId { get; set; }
    public User User { get; set; }
    [Key]
    public int ServiceManagerId { get; set; }

    public AutoService? AutoService { get; set; }
    public int? AutoServiceId { get; set; }
}