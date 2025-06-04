using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Voyage;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/admin/voyages")]
    public class VoyageController : ControllerBase
    {
        private readonly IVoyageService _voyageService;

        public VoyageController(IVoyageService voyageService)
        {
            _voyageService = voyageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoyageDto>>> GetAll()
            => Ok(await _voyageService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<VoyageDto>> GetById(string id)
        {
            var result = await _voyageService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VoyageDto>> Create([FromBody] VoyageCreateDto dto)
        {
            var created = await _voyageService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] VoyageCreateDto dto)
        {
            var updated = await _voyageService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _voyageService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
