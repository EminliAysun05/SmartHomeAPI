using SmartHomeAPI.Business.Dtos.LocationDtos;

namespace SmartHomeAPI.Business.Services.Abstractions;

public interface ILocationService
{
    Task<List<LocationGetDto>> GetAllLocations();
    Task<LocationGetDto>  CreateLocation(LocationCreateDto locationCreateDto);
   // Task<LocationWithDevicesDto?> GetLocationWithDevicesAsync(int id);

}
