using AutoServiceConnect.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceConnect.Api.Database;

public class AutoServiceDbContext(DbContextOptions<AutoServiceDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AutoService> AutoServices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AutoServiceManager> AutoServiceManagers { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Blog>()
        //     .HasOne(e => e.Header)
        //     .WithOne(e => e.Blog)
        //     .HasForeignKey<BlogHeader>(e => e.BlogId)
        //     .IsRequired();
        modelBuilder.Entity<User>()
            .HasOne(u => u.ServiceManager)
            .WithOne(asm => asm.User)
            .HasForeignKey<AutoServiceManager>(asm => asm.UserId);
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.Customer)
            .WithOne(c => c.User)
            .HasForeignKey<Customer>(c => c.UserId);
        
        base.OnModelCreating(modelBuilder);
    }
}