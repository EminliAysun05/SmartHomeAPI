using SmartHomeAPI.Business.Dtos.DeviceDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IDeviceService
{
    Task<List<DeviceGetDto>> GetAllAsync();
    Task<DeviceGetDto?> GetByIdAsync(int id);
    Task<DeviceGetDto> CreateAsync(DeviceCreateDto deviceCreateDto);
    Task<DeviceGetDto?> UpdateAsync(int id, DeviceUpdateDto deviceUpdateDto);
    Task<bool> DeleteAsync(int id);
}
