using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Business.Services.Implementations;
using System.Reflection;

namespace SmartHomeAPI.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
       AddServices(services);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddHttpClient();

        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddHttpContextAccessor();
        return services;
    }

    private static void AddServices(IServiceCollection services)
    {

       services.AddScoped<IAuthService, AuthService>();
       services.AddScoped<ILocationService, LocationService>();
       services.AddScoped<IDeviceCategoryService, DeviceCategoryService>();
       services.AddScoped<IDeviceService, DeviceService>();
       services.AddScoped<ISensorReadingService, SensorReadingService>();
       services.AddScoped<IAnalyticService, AnalyticService>();

    }
}
