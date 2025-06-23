using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.LocationDtos;
using SmartHomeAPI.Business.Services.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Tags("Location Management")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
      

        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }

        //[HttpGet("{id}/devices")]
        //public async Task<IActionResult> GetLocationWithDevices(int id)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationCreateDto locationCreateDto)
        {
            if (locationCreateDto == null)
            {
                return BadRequest("Location data is null.");
            }

            var createdLocation = await _locationService.CreateLocation(locationCreateDto);
            return CreatedAtAction(nameof(GetAll), new { id = createdLocation.Id }, createdLocation);
        }
    }
}
