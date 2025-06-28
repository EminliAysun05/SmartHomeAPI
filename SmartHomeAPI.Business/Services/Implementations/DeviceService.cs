using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Dtos.PaginationDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;

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
    public async Task<PagedResultDto<DeviceGetDto>> GetPaginatedAsync(int page, int pageSize)
    {
        var query = _deviceRepository.GetAll();
        var totalCount = await query.CountAsync();
        var paginatedQuery = _deviceRepository.Paginate(query, pageSize, page);
        var allDevices = paginatedQuery.ToListAsync();

        var dtoList = _mapper.Map<List<DeviceGetDto>>(allDevices);

        return new PagedResultDto<DeviceGetDto>
        {
            TotalCount = totalCount,
            PageSize = pageSize,
            Page = page,
            Items = dtoList
        };

    }

    public async Task<List<DeviceGetDto>> SearchByName(string name)
    {
        var devices = await _deviceRepository.GetAll()
            .Where(d => d.Name.Contains(name.ToLower()))
            .ToListAsync();

       
        var dtos = _mapper.Map<List<DeviceGetDto>>(devices);
        return dtos;
    }

    public async Task<List<DeviceGetDto>> GetOnlineDevices(string name)
    {
        var onlineDevices = await _deviceRepository.GetAll()
            .Where(d => d.IsOnline && d.Name.Contains(name.ToLower()))
            .ToListAsync();

        var dtos = _mapper.Map<List<DeviceGetDto>>(onlineDevices);
        return dtos;
    }

    public async Task<List<DeviceGetDto>> GetDevicesByLocationIdAsync(int locationId)
    {
        var devices = await _deviceRepository.GetAll()
            .Where(d => d.LocationId == locationId)
            .ToListAsync();
        var dtos = _mapper.Map<List<DeviceGetDto>>(devices);
        return dtos;
    }
}
