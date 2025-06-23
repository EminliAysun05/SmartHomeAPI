using AutoMapper;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.AutoMappers.DeviceAutoMappers;

public class DeviceCreateAutoMapper : Profile
{
    public DeviceCreateAutoMapper()
    {
        CreateMap<Device, DeviceGetDto>().ReverseMap();
        CreateMap<DeviceCreateDto, Device>().ReverseMap();
        CreateMap<DeviceUpdateDto, Device>().ReverseMap();
    }
}
