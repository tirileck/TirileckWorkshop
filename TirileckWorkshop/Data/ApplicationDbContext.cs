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
        modelBuilder.Entity<DeviceType>()
            .HasData(new[]
            {
                new DeviceType() { Id = 1, Name = "Другое" },
                new DeviceType() { Id = 2, Name = "ПК" },
                new DeviceType() { Id = 3, Name = "Ноутбук" },
                new DeviceType() { Id = 4, Name = "Телефон" },
                new DeviceType() { Id = 5, Name = "Планшет" },
                new DeviceType() { Id = 6, Name = "Телевизор" },
                new DeviceType() { Id = 7, Name = "Принтер" },
            });
        
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
        modelBuilder.Entity<Order>()
            .Property(b => b.StatusHistory)
            .HasColumnType("jsonb");
        
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