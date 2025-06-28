using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.SensorReadingDtos;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SensorReadingController : ControllerBase
{
    private readonly ISensorReadingService _sensorReadingService;

    public SensorReadingController(ISensorReadingService sensorReadingService)
    {
        _sensorReadingService = sensorReadingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sensorReadings = await _sensorReadingService.GetAllAsync();
        return Ok(sensorReadings);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sensorReading = await _sensorReadingService.GetById(id);
        if (sensorReading == null)
            return NotFound();
        return Ok(sensorReading);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SensorReadingCreateDto sensorReadingCreateDto)
    {
        if (sensorReadingCreateDto == null)
            return BadRequest("Sensor reading data is null.");

        var createdSensorReading = await _sensorReadingService.CreateAsync(sensorReadingCreateDto);
        return CreatedAtAction(nameof(GetById), new { id = createdSensorReading.Id }, createdSensorReading);
    }

    [HttpGet("latest/{deviceId}")]
    public async Task<IActionResult> GetLatestByDeviceId(int deviceId)
    {
        var latestSensorReading = await _sensorReadingService.GetLatestsByDeviceIdAsync(deviceId);
        if (latestSensorReading == null)
            return NotFound($"No sensor readings found for device with ID {deviceId}.");
        return Ok(latestSensorReading);
    }
}
