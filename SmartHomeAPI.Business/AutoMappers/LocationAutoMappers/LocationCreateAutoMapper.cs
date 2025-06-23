using AutoMapper;
using SmartHomeAPI.Business.Dtos.LocationDtos;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;

public class LocationCreateAutoMapper : Profile
{
    public LocationCreateAutoMapper()
    {
        CreateMap<Location, LocationGetDto>().ReverseMap();
       // CreateMap<Location, LocationWithDevicesDto>().ReverseMap();
        CreateMap<LocationCreateDto, Location>().ReverseMap();
    }
}
