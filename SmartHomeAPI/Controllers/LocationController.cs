using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.LocationDtos;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _locationService.GetAllLocations();
        return Ok(locations);
    }

    [HttpGet("{id}/devices")]
    public async Task<IActionResult> GetLocationWithDevices(int id)
    {
        var locationWithDevices = await _locationService.GetLocationWithDevicesAsync(id);
        if (locationWithDevices == null)
            return NotFound($"Location with ID {id} not found.");
        return Ok(locationWithDevices);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LocationCreateDto locationCreateDto)
    {
        if (locationCreateDto == null)
            return BadRequest("Location data is null.");

        var createdLocation = await _locationService.CreateLocation(locationCreateDto);
        return CreatedAtAction(nameof(GetAll), new { id = createdLocation.Id }, createdLocation);
    }
    
}
