using Microsoft.EntityFrameworkCore;
using TirileckWorkshop.Data.Enums;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
        
    }

    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Workshop> WorkShops { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceType>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Role>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Workshop>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Order>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Order>()
            .HasOne(x => x.DeviceType)
            .WithMany()
            .HasForeignKey(x => x.DeviceTypeId);
        modelBuilder.Entity<Order>()
            .HasOne(x => x.Workshop)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.WorkshopId);
        
        modelBuilder.Entity<User>()
            .HasOne(x => x.Workshop)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.WorkshopId);
        modelBuilder.Entity<User>()
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users);
        
        
        base.OnModelCreating(modelBuilder);
    }
}