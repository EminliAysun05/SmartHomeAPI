using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.DeviceDtos;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var devices = await _deviceService.GetAllAsync();
        return Ok(devices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var device = await _deviceService.GetByIdAsync(id);
        if (device == null)
            return NotFound();
        return Ok(device);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeviceCreateDto deviceCreateDto)
    {
        if (deviceCreateDto == null)
            return BadRequest("Device data is null.");

        var createdDevice = await _deviceService.CreateAsync(deviceCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = createdDevice.Id }, createdDevice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DeviceUpdateDto dto)
    {
        var updatedDevice = await _deviceService.UpdateAsync(id, dto);
        return updatedDevice != null ? Ok(updatedDevice) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _deviceService.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginatedDevices([FromQuery] int page = 1, [FromQuery] int pageSize = 1)
    {
        var paginatedDevices = await _deviceService.GetPaginatedAsync(page, pageSize);
        return Ok(paginatedDevices);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Search name cannot be empty.");

        var devices = await _deviceService.SearchByName(name);
        return Ok(devices);
    }
    [HttpGet("online-devices")]
    public async Task<IActionResult> GetOnlineDevices([FromQuery] string name)
    {
        var onlineDevices = await _deviceService.GetOnlineDevices(name);
        return Ok(onlineDevices);
    }
}



