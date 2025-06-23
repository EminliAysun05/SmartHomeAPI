using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Business.Dtos.DeviceCategoryDtos;
using SmartHomeAPI.Business.Services.Abstractions;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceCategoryController : ControllerBase
    {
        private readonly IDeviceCategoryService _service;

        public DeviceCategoryController(IDeviceCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceCategoryCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
