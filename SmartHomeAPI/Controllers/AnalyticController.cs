using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticController : ControllerBase
{
    private readonly IAnalyticService _analyticsService;

    public AnalyticController(IAnalyticService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("energy-usage")]
    public async Task<IActionResult> GetEnergyUsageAnalytics()
    {
       
        var totalUsage = await _analyticsService.GetTotalEnergyUsageAsync();
        return Ok(new { totalEnergyUsage = totalUsage });
    }

    [HttpGet("device-status")]
    public async Task<IActionResult> GetDeviceStatus()
    {
        var (online, offline) = await _analyticsService.GetDeviceStatusAsync();
        return Ok(new { onlineDevices = online, offlineDevices = offline });
    }

    [HttpGet("location-usage")]
    public async Task<IActionResult> GetLocationUsage()
    {
        var locationUsage = await _analyticsService.GetLocationUsageAnalytics();
        return Ok(locationUsage);
    }

    [HttpGet("devices/health")]
    public async Task<IActionResult> GetDeviceHealth()
    {
        var deviceHealth = await _analyticsService.GetDeviceHealthyReportAsync();
        return Ok(deviceHealth);
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginatedDevices([FromQuery] int page = 1, [FromQuery] int pageSize = 1)
    {
        var paginatedDevices = await _analyticsService.GetPaginatedAsync(page, pageSize);
        return Ok(paginatedDevices);
    }
}
