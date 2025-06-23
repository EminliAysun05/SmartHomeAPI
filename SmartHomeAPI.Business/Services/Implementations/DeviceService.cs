using AutoMapper;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.DataAccess.Repositories.Abstractions;

namespace SmartHomeAPI.Business.Services.Implementations;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;

    public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _mapper = mapper;
    }

    public async Task<DeviceGetDto> CreateAsync(DeviceCreateDto deviceCreateDto)
    {
        var entity = _mapper.Map<Device>(deviceCreateDto);
        await _deviceRepository.CreateAsync(entity);
        await _deviceRepository.SaveChangesAsync();
        var dto = _mapper.Map<DeviceGetDto>(entity);
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var device = await _deviceRepository.GetAsync(id);
        if(device == null)
            return false; 

        _deviceRepository.Delete(device);
        await _deviceRepository.SaveChangesAsync();
        return true;
    }

    public async Task<List<DeviceGetDto>> GetAllAsync()
    {
       var devices = _deviceRepository.GetAll();
        var dtos = _mapper.Map<List<DeviceGetDto>>(devices);
        return dtos;
    }

    //bax
    public async Task<DeviceGetDto?> GetByIdAsync(int id)
    {
        var device = await _deviceRepository.GetAsync(id);
        if (device == null)
            return null;

        var dto = _mapper.Map<DeviceGetDto>(device);
        return dto;
    }

    public async Task<DeviceGetDto?> UpdateAsync(int id, DeviceUpdateDto deviceUpdateDto)
    {
        var device = await _deviceRepository.GetAsync(id);
        if(device == null)
            return null;
        _mapper.Map(deviceUpdateDto, device);
        await _deviceRepository.SaveChangesAsync();
        var dto = _mapper.Map<DeviceGetDto>(device);
        return dto;


    }
}
