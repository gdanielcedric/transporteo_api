using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.DTOs.Ticket;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context) => _context = context;

        public async Task<TicketDto> BuyTicketAsync(string userId, string voyageId)
        {
            var voyage = await _context.Voyages.FindAsync(voyageId);
            if (voyage == null || voyage.AvailableSeats <= 0)
                throw new Exception("Voyage invalide ou complet.");

            var ticket = new Ticket
            {
                UserId = userId,
                VoyageId = voyageId
            };

            voyage.AvailableSeats -= 1;

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return new TicketDto { UserId = userId, VoyageId = voyageId };
        }

        public async Task<IEnumerable<TicketDto>> GetByUserIdAsync(string userId)
        {
            return await _context.Tickets
                .Where(t => t.UserId == userId)
                .Select(t => new TicketDto
                {
                    UserId = t.UserId,
                    VoyageId = t.VoyageId
                }).ToListAsync();
        }
    }

}
