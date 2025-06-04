using Transporteo.DTOs.Ligne;

namespace Transporteo.Services.Interfaces
{
    public interface ILigneService
    {
        Task<IEnumerable<LigneDto>> GetAllAsync();
        Task<LigneDto?> GetByIdAsync(string id);
        Task<LigneDto> CreateAsync(LigneCreateDto dto);
        Task<bool> UpdateAsync(string id, LigneCreateDto dto);
        Task<bool> DeleteAsync(string id);
    }

}
