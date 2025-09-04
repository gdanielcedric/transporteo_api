using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Chauffeur;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/admin/chauffeurs")]
    public class ChauffeurController : ControllerBase
    {
        private readonly IChauffeurService _chauffeurService;

        public ChauffeurController(IChauffeurService chauffeurService)
        {
            _chauffeurService = chauffeurService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChauffeurDto>>> GetAll()
        {
            var result = await _chauffeurService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChauffeurDto>> GetById(string id)
        {
            var result = await _chauffeurService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChauffeurCreateDto dto)
        {
            var created = await _chauffeurService.CreateAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ChauffeurCreateDto dto)
        {
            var updated = await _chauffeurService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _chauffeurService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
