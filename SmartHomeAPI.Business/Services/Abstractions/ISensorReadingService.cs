using SmartHomeAPI.Business.Dtos.SensorReadingDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface ISensorReadingService
{
    Task<List<SensorReadingGetDto>> GetAllAsync();
   Task<SensorReadingGetDto> GetById(int id);
    Task<SensorReadingGetDto> CreateAsync(SensorReadingCreateDto sensorReadingCreateDto);
    Task<SensorReadingGetDto?> GetLatestsByDeviceIdAsync(int deviceId);
}
