using AutoMapper;
using SmartHomeAPI.Business.Dtos.DeviceCategoryDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;

namespace SmartHomeAPI.Business.Services.Implementations;

public class DeviceCategoryService : IDeviceCategoryService
{
    private readonly IDeviceCategoryRepository _deviceCategoryRepository;
    private readonly IMapper _mapper;

    public DeviceCategoryService(IDeviceCategoryRepository repo, IMapper mapper)
    {
        _deviceCategoryRepository = repo;
        _mapper = mapper;
    }

    public async Task<List<DeviceCategoryGetDto>> GetAllAsync()
    {
        var list = _deviceCategoryRepository.GetAll().ToList();
        var result = _mapper.Map<List<DeviceCategoryGetDto>>(list);
        return result;
    }

    public async Task<DeviceCategoryGetDto> CreateAsync(DeviceCategoryCreateDto dto)
    {
        var entity = _mapper.Map<DeviceCategory>(dto);
        await _deviceCategoryRepository.CreateAsync(entity);
        await _deviceCategoryRepository.SaveChangesAsync();
        var result = _mapper.Map<DeviceCategoryGetDto>(entity);
        return result;
    }
}
