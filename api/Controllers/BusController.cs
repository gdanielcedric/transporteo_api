using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Bus;
using Transporteo.Services.Interfaces;

namespace api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/admin/bus")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _service;
        public BusController(IBusService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var bus = await _service.GetByIdAsync(id);
            return bus == null ? NotFound() : Ok(bus);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BusCreateDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] BusCreateDto dto) =>
            await _service.UpdateAsync(id, dto) ? Ok() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) =>
            await _service.DeleteAsync(id) ? Ok() : NotFound();
    }

}
