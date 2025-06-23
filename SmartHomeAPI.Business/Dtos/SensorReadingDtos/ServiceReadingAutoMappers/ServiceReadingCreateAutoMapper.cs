using AutoMapper;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.Dtos.SensorReadingDtos.ServiceReadingAutoMappers;

public class ServiceReadingCreateAutoMapper : Profile
{
    public ServiceReadingCreateAutoMapper()
    {

        CreateMap<SensorReading, SensorReadingGetDto>().ReverseMap();
        CreateMap<SensorReadingCreateDto, SensorReading>().ReverseMap();
    }
}
