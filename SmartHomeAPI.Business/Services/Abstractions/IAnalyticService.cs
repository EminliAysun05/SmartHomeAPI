using SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;
using SmartHomeAPI.Business.Dtos.AnalyticDtos;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Dtos.PaginationDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IAnalyticService
{
    Task<double> GetTotalEnergyUsageAsync();
    Task<(int online, int offline)> GetDeviceStatusAsync();
    Task<List<LocationUsageDto>> GetLocationUsageAnalytics();
    Task<List<DeviceHealthyReportDto>> GetDeviceHealthyReportAsync();
    Task<PagedResultDto<DeviceGetDto>> GetPaginatedAsync(int page, int pageSize);
}
