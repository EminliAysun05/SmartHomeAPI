using SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;
using SmartHomeAPI.Business.Dtos.AnalyticDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IAnalyticService
{
    Task<double> GetTotalEnergyUsageAsync();
    Task<(int online, int offline)> GetDeviceStatusAsync();
    Task<List<LocationUsageDto>> GetLocationUsageAnalytics();
    Task<List<DeviceHealthyReportDto>> GetDeviceHealthyReportAsync();
   
}
