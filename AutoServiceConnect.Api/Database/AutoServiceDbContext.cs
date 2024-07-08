using AutoServiceConnect.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Database;

public class AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AutoService> AutoServices { get; set; }
}