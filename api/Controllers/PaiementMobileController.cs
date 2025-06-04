using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Paiement;

namespace Transporteo.Controllers
{
    [ApiController]
    [Route("api/mobile/paiements")]
    public class PaiementMobileController : ControllerBase
    {
        private readonly IPaiementService _paiementService;

        public PaiementMobileController(IPaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        [HttpPost]
        public async Task<ActionResult<PaiementDto>> Create([FromBody] PaiementCreateDto dto)
        {
            var result = await _paiementService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByReservation), new { reservationId = dto.ReservationId }, result);
        }

        [HttpGet("reservation/{reservationId}")]
        public async Task<ActionResult<IEnumerable<PaiementDto>>> GetByReservation(string reservationId)
        {
            return Ok(await _paiementService.GetByReservationIdAsync(reservationId));
        }
    }
}
