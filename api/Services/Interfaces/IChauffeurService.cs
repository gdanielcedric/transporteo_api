using Transporteo.DTOs.Chauffeur;

namespace Transporteo.Services.Interfaces
{
    public interface IChauffeurService
    {
        Task<IEnumerable<ChauffeurDto>> GetAllAsync();
        Task<ChauffeurDto?> GetByIdAsync(string id);
        Task<ChauffeurDto> CreateAsync(ChauffeurCreateDto dto);
        Task<bool> UpdateAsync(string id, ChauffeurCreateDto dto);
        Task<bool> DeleteAsync(string id);
    }

}
