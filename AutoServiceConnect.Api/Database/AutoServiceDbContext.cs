using AutoServiceConnect.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Database;

public class AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}