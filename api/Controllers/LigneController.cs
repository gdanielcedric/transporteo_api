using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Ligne;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [ApiController]
    [Route("api/admin/lignes")]
    public class LigneController : ControllerBase
    {
        private readonly ILigneService _ligneService;

        public LigneController(ILigneService ligneService)
        {
            _ligneService = ligneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LigneDto>>> GetAll()
        {
            var lignes = await _ligneService.GetAllAsync();
            return Ok(lignes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LigneDto>> GetById(string id)
        {
            var ligne = await _ligneService.GetByIdAsync(id);
            return ligne == null ? NotFound() : Ok(ligne);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LigneCreateDto dto)
        {
            var created = await _ligneService.CreateAsync(dto);
            return Ok(created);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LigneCreateDto dto)
        {
            var updated = await _ligneService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _ligneService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
