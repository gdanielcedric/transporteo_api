using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Paiement;

namespace Transporteo.Controllers
{
    [ApiController]
    [Route("api/admin/paiements")]
    public class PaiementAdminController : ControllerBase
    {
        private readonly IPaiementService _paiementService;

        public PaiementAdminController(IPaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaiementDto>>> GetAll()
        {
            return Ok(await _paiementService.GetAllAsync());
        }
    }
}
