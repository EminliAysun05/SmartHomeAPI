using AutoMapper;
using SmartHomeAPI.Business.Dtos.LocationDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.DataAccess.Repositories.Abstractions;

namespace SmartHomeAPI.Business.Services.Implementations;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<LocationGetDto> CreateLocation(LocationCreateDto locationCreateDto)
    {
        var entity = _mapper.Map<Location>(locationCreateDto);
        await _locationRepository.CreateAsync(entity);
        await _locationRepository.SaveChangesAsync();
        var result = _mapper.Map<LocationGetDto>(entity);
        return result;

    }

    public async Task<List<LocationGetDto>> GetAllLocations()
    {
        var locations = _locationRepository.GetAll();
        var dtoList = _mapper.Map<List<LocationGetDto>>(locations.ToList());
        return dtoList;
    }

    //public Task<LocationWithDevicesDto?> GetLocationWithDevicesAsync(int id)
    //{

    //}
}
