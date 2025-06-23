using AutoMapper;
using SmartHomeAPI.Business.Dtos.DeviceCategoryDtos;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.AutoMappers.DeviceCategoryAutoMappers;

public class DeviceCategoryAutoMapper : Profile
{
    public DeviceCategoryAutoMapper()
    {
        CreateMap<DeviceCategory, DeviceCategoryGetDto>().ReverseMap();
        CreateMap<DeviceCategoryCreateDto, DeviceCategory>().ReverseMap();
    }
}
