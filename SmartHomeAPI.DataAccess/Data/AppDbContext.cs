using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Core.Entities;
using System.Reflection;

namespace SmartHomeAPI.DataAccess.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);


    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceCategory> DeviceCategories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SensorReading> SensorReading { get; set; }
    public DbSet<UserDevice> UserDevices { get; set; }
}
