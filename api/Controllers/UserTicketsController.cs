using Microsoft.AspNetCore.Mvc;
using Transporteo.Services.Interfaces;

namespace Transporteo.Controllers
{
    [Route("api/mobile/tickets")]
    [ApiController]
    public class UserTicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public UserTicketsController(ITicketService ticketService) => _ticketService = ticketService;

        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromQuery] string userId, [FromQuery] string voyageId)
        {
            try
            {
                var ticket = await _ticketService.BuyTicketAsync(userId, voyageId);
                return Ok(ticket);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUser(string userId) =>
            Ok(await _ticketService.GetByUserIdAsync(userId));
    }

}
