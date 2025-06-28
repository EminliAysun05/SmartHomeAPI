using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;
using SmartHomeAPI.DataAccess.Data;
using SmartHomeAPI.DataAccess.DataInitializers;
using SmartHomeAPI.DataAccess.Repositories.Implementations;

namespace SmartHomeAPI.DataAccess.ServiceRegistrations;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("Default")));


        services.AddScoped<DbContextInitializer>();

        services.AddMemoryCache();
        services.AddScoped<AppUser>();

        AddIdentity(services);
        AddRepositories(services);

        return services;
    }
    private static void AddIdentity(IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Lockout.AllowedForNewUsers = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;

        }).AddEntityFrameworkStores<AppDbContext>()
          .AddDefaultTokenProviders();
          
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IDeviceCategoryRepository, DeviceCategoryRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ISensorReadingRepository, SensorReadingRepository>();
        services.AddScoped<IUserDeviceRepository, UserDeviceRepository>();
    }
}
