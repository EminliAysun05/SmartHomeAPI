using SmartHomeAPI.Business.Dtos.DeviceCategoryDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface IDeviceCategoryService
{
    Task<List<DeviceCategoryGetDto>> GetAllAsync();
    Task<DeviceCategoryGetDto> CreateAsync(DeviceCategoryCreateDto dto);
}
