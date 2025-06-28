using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Business.Dtos.SensorReadingDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.Core.Entities;
using SmartHomeAPI.Core.Repositories.Abstractions;

namespace SmartHomeAPI.Business.Services.Implementations;

public class SensorReadingService : ISensorReadingService
{
    private readonly ISensorReadingRepository _serviceReadingRepository;
    private readonly IMapper _mapper;

    public SensorReadingService(ISensorReadingRepository serviceReadingRepository, IMapper mapper)
    {
        _serviceReadingRepository = serviceReadingRepository;
        _mapper = mapper;
    }

    public async Task<SensorReadingGetDto> CreateAsync(SensorReadingCreateDto sensorReadingCreateDto)
    {
        var reading = _mapper.Map<SensorReading>(sensorReadingCreateDto);
        await _serviceReadingRepository.CreateAsync(reading);
        await _serviceReadingRepository.SaveChangesAsync();
        var dto = _mapper.Map<SensorReadingGetDto>(reading);
        return dto;

    }

  
    public async Task<List<SensorReadingGetDto>> GetAllAsync()
    {
        var readings = await _serviceReadingRepository.GetAll().ToListAsync();
        var dtos = _mapper.Map<List<SensorReadingGetDto>>(readings);
        return dtos;
    }

  
    public async Task<SensorReadingGetDto> GetById(int id)
    {
        var reading = await _serviceReadingRepository.GetAsync(id);
        if (reading == null) return null;

        var dto = _mapper.Map<SensorReadingGetDto>(reading);
        return dto;
    }

    
    public async Task<SensorReadingGetDto?> GetLatestsByDeviceIdAsync(int deviceId)
    {
        var latestDevice = await _serviceReadingRepository.GetAll().
            Where(x => x.DeviceId == deviceId)
            .OrderByDescending(x => x.Timestamp)
            .FirstOrDefaultAsync();

        if(latestDevice == null)
            return null;
        var dto = _mapper.Map<SensorReadingGetDto>(latestDevice);
        return dto;

    }
}
