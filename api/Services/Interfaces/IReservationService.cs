using Transporteo.DTOs.Reservation;

namespace Transporteo.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateAsync(ReservationCreateDto dto);
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<ReservationDto?> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<ReservationStatDto>> GetStatsAsync();
    }
}
