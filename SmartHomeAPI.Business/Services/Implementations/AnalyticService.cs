using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHomeAPI.Business.AutoMappers.LocationAutoMappers;
using SmartHomeAPI.Business.Dtos.AnalyticDtos;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Dtos.PaginationDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using SmartHomeAPI.DataAccess.Repositories.Abstractions;

namespace SmartHomeAPI.Business.Services.Implementations;

public class AnalyticService : IAnalyticService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;

    public AnalyticService(IDeviceRepository deviceRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _mapper = mapper;
    }

    public async Task<List<DeviceHealthyReportDto>> GetDeviceHealthyReportAsync()
    {
        var reports = await _deviceRepository.GetAll()
            .GroupBy(d => d.IsOnline ? "Online" : "Offline")
            .Select(g => new DeviceHealthyReportDto
            {
                HealthyStatus = g.Key,
                Count = g.Count()
            })
            .ToListAsync();

        return reports;
    }

    public async Task<(int online, int offline)> GetDeviceStatusAsync()
    {
        var allDevices = await _deviceRepository.GetAll().ToListAsync();
        int online = allDevices.Count(d => d.IsOnline);
        int offline = allDevices.Count - online;
        return (online, offline);
    }

    public Task<List<LocationUsageDto>> GetLocationUsageAnalytics()
    {
        var locationUsage = _deviceRepository.GetAll()
           .Select(d => new LocationUsageDto
           {
               LocationName = d.Location.Name,
               DeviceCount = d.Location.Devices.Count,
           });
        return locationUsage.ToListAsync();
    }


    public async Task<double> GetTotalEnergyUsageAsync()
    {
        var totalEnergy = await _deviceRepository.GetAll()
        .SumAsync(d => d.PowerUsage);
        return totalEnergy;
    }

}
