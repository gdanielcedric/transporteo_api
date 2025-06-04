using Transporteo.DTOs.Ticket;

namespace Transporteo.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDto> BuyTicketAsync(string userId, string voyageId);
        Task<IEnumerable<TicketDto>> GetByUserIdAsync(string userId);
    }

}
