using AutoMapper;
using SmartHomeAPI.Business.Dtos.AppUserDtos;
using SmartHomeAPI.Core.Entities;

namespace SmartHomeAPI.Business.AutoMappers;

public class AppUserAutoMapper : Profile
{
    public AppUserAutoMapper()
    {
        CreateMap<AppUser, LoginDto>().ReverseMap();
        CreateMap<AppUser, RegisterDto>().ReverseMap();
    }
}
