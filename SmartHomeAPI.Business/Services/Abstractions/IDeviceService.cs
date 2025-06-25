using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Dtos.PaginationDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IDeviceService
{
    Task<List<DeviceGetDto>> GetAllAsync();
    Task<DeviceGetDto?> GetByIdAsync(int id);
    Task<DeviceGetDto> CreateAsync(DeviceCreateDto deviceCreateDto);
    Task<DeviceGetDto?> UpdateAsync(int id, DeviceUpdateDto deviceUpdateDto);
    Task<bool> DeleteAsync(int id);
    Task<PagedResultDto<DeviceGetDto>> GetPaginatedAsync(int page, int pageSize);
    Task<List<DeviceGetDto>> SearchByName(string name);
    Task<List<DeviceGetDto>> GetOnlineDevices(string name);
    Task<List<DeviceGetDto>> GetDevicesByLocationIdAsync(int locationId);
}
