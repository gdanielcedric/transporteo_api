using Transporteo.DTOs.Voyage;

namespace Transporteo.Services.Interfaces
{
    public interface IVoyageService
    {
        Task<IEnumerable<VoyageDto>> GetAllAsync();
        Task<VoyageDto> GetByIdAsync(string id);
        Task<VoyageDto> CreateAsync(VoyageCreateDto dto);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(string id, VoyageCreateDto dto);
    }

}
