using AutoMapper;
using SmartHomeAPI.Business.Dtos.LocationDtos;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;

public class LocationCreateAutoMapper : Profile
{
    public LocationCreateAutoMapper()
    {
        CreateMap<Location, LocationGetDto>().ReverseMap();
        CreateMap<LocationCreateDto, Location>().ReverseMap();
        CreateMap<Location, LocationWithDevicesDto>()
        .ForMember(dest => dest.Devices, opt => opt.MapFrom(src => src.Devices));
        CreateMap<Device, DeviceDto>().ReverseMap();
    }
}
