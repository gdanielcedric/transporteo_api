using Transporteo.DTOs.Bus;

namespace Transporteo.Services.Interfaces
{
    public interface IBusService
    {
        Task<IEnumerable<BusDto>> GetAllAsync();
        Task<BusDto> GetByIdAsync(string id);
        Task<BusDto> CreateAsync(BusCreateDto dto);
        Task<bool> UpdateAsync(string id, BusCreateDto dto);
        Task<bool> DeleteAsync(string id);
    }

}
