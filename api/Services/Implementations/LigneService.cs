using Microsoft.EntityFrameworkCore;
using System;
using Transporteo.Data;
using Transporteo.DTOs.Ligne;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class LigneService : ILigneService
    {
        private readonly ApplicationDbContext _context;
        public LigneService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<LigneDto>> GetAllAsync() =>
            await _context.Lignes.Select(l => new LigneDto
            {
                VilleDepart = l.VilleDepart,
                VilleArrivee = l.VilleArrivee
            }).ToListAsync();

        public async Task<LigneDto?> GetByIdAsync(string id)
        {
            var l = await _context.Lignes.FindAsync(id);
            return l == null ? null : new LigneDto
            {
                VilleDepart = l.VilleDepart,
                VilleArrivee = l.VilleArrivee
            };
        }

        public async Task<LigneDto> CreateAsync(LigneCreateDto dto)
        {
            var l = new Ligne
            {
                VilleDepart = dto.VilleDepart,
                VilleArrivee = dto.VilleArrivee
            };
            _context.Lignes.Add(l);
            await _context.SaveChangesAsync();
            return new LigneDto { VilleDepart = l.VilleDepart, VilleArrivee = l.VilleArrivee };
        }

        public async Task<bool> UpdateAsync(string id, LigneCreateDto dto)
        {
            var l = await _context.Lignes.FindAsync(id);
            if (l == null) return false;

            l.VilleDepart = dto.VilleDepart;
            l.VilleArrivee = dto.VilleArrivee;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var l = await _context.Lignes.FindAsync(id);
            if (l == null) return false;

            _context.Lignes.Remove(l);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
