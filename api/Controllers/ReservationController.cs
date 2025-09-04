using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporteo.DTOs.Reservation;
using Transporteo.Services.Interfaces;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/mobile/reservations")]
    public class ReservationMobileController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationMobileController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDto>> Create([FromBody] ReservationCreateDto dto)
        {
            var result = await _reservationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAll()
        {
            return Ok(await _reservationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetById(string id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("stats")]
        public async Task<ActionResult<IEnumerable<ReservationStatDto>>> GetStats()
        {
            var stats = await _reservationService.GetStatsAsync();
            return Ok(stats);
        }

    }
}
