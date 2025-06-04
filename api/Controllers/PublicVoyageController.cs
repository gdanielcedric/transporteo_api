using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Ligne;
using Transporteo.DTOs.Voyage;
using Transporteo.Services.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("api/mobile/public")]
    public class PublicVoyageController : ControllerBase
    {
        private readonly IVoyageService _voyageService;
        private readonly ILigneService _ligneService;

        public PublicVoyageController(IVoyageService voyageService, ILigneService ligneService)
        {
            _voyageService = voyageService;
            _ligneService = ligneService;
        }

        [HttpGet("voyages")]
        public async Task<ActionResult<IEnumerable<VoyageDto>>> GetVoyages()
            => Ok(await _voyageService.GetAllAsync());

        [HttpGet("lignes")]
        public async Task<ActionResult<IEnumerable<LigneDto>>> GetLignes()
            => Ok(await _ligneService.GetAllAsync());

        [HttpGet("voyages/{id}")]
        public async Task<ActionResult<VoyageDto>> GetVoyage(string id)
        {
            var result = await _voyageService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("lignes/{id}")]
        public async Task<ActionResult<LigneDto>> GetLigne(string id)
        {
            var result = await _ligneService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
