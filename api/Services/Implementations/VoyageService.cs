using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.DTOs.Voyage;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class VoyageService : IVoyageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VoyageService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VoyageDto>> GetAllAsync()
        {
            var voyages = await _context.Voyages
                .Include(v => v.Ligne)
                .Include(v => v.Bus)
                .Include(v => v.Chauffeur)
                .ToListAsync();

            return _mapper.Map<IEnumerable<VoyageDto>>(voyages);
        }

        public async Task<VoyageDto?> GetByIdAsync(string id)
        {
            var voyage = await _context.Voyages
                .Include(v => v.Ligne)
                .Include(v => v.Bus)
                .Include(v => v.Chauffeur)
                .FirstOrDefaultAsync(v => v.Id == id);

            return voyage == null ? null : _mapper.Map<VoyageDto>(voyage);
        }

        public async Task<VoyageDto> CreateAsync(VoyageCreateDto dto)
        {
            var voyage = _mapper.Map<Voyage>(dto);
            _context.Voyages.Add(voyage);
            await _context.SaveChangesAsync();

            return _mapper.Map<VoyageDto>(voyage);
        }

        public async Task<bool> UpdateAsync(string id, VoyageCreateDto dto)
        {
            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null) return false;

            _mapper.Map(dto, voyage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null) return false;

            _context.Voyages.Remove(voyage);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
