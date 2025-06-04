using Transporteo.DTOs.Paiement;

namespace api.Services.Interfaces
{
    public interface IPaiementService
    {
        Task<PaiementDto> CreateAsync(PaiementCreateDto dto);
        Task<IEnumerable<PaiementDto>> GetAllAsync();
        Task<IEnumerable<PaiementDto>> GetByReservationIdAsync(string reservationId);
    }
}
