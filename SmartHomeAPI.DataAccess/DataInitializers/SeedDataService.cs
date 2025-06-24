using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.DataAccess.DataInitializers;

public static class SeedDataService
{
    public static void AddSeedData(this ModelBuilder builder)
    {
        builder.AddDeviceCategories();
        builder.AddLocations();
        builder.AddDevices();
    }

    public static void AddDeviceCategories(this ModelBuilder builder)
    {
        builder.Entity<DeviceCategory>().HasData(
            new DeviceCategory { Id = 4, Name = "Sensor", Description = "Sensor devices" },
            new DeviceCategory { Id = 5, Name = "Actuator", Description = "Devices that act on data" },
            new DeviceCategory { Id = 6, Name = "Camera", Description = "Security and monitoring devices" }
        );
    }

    public static void AddLocations(this ModelBuilder builder)
    {
        builder.Entity<Location>().HasData(
            new Location { Id = 4, Name = "Living Room", Floor = 1, RoomType = "Common" },
            new Location { Id = 5, Name = "Kitchen", Floor = 1, RoomType = "Food" },
            new Location { Id = 6, Name = "Bedroom", Floor = 2, RoomType = "Private" },
            new Location { Id = 7, Name = "Garage", Floor = 0, RoomType = "Storage" }
        );
    }

    public static void AddDevices(this ModelBuilder builder)
    {
        builder.Entity<Device>().HasData(
            new Device { Id = 4, Name = "Temperature Sensor", IsOnline = true, PowerUsage = 2.5, HealthStatus = "Healthy", CategoryId = 4, LocationId = 4 },
            new Device { Id = 5, Name = "Motion Sensor", IsOnline = false, PowerUsage = 1.2, HealthStatus = "Warning", CategoryId = 4, LocationId = 5 },
            new Device { Id = 6, Name = "Smart Light", IsOnline = true, PowerUsage = 3.0, HealthStatus = "Healthy", CategoryId = 5, LocationId = 4 },
            new Device { Id = 7, Name = "Smart Plug", IsOnline = false, PowerUsage = 0.5, HealthStatus = "Critical", CategoryId = 5, LocationId = 6 },
            new Device { Id = 8, Name = "Security Camera", IsOnline = true, PowerUsage = 4.0, HealthStatus = "Healthy", CategoryId = 6, LocationId = 7 }
        );
    }
}
