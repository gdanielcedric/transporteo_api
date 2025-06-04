using Microsoft.EntityFrameworkCore;
using System;
using Transporteo.Data;
using Transporteo.DTOs.Chauffeur;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class ChauffeurService : IChauffeurService
    {
        private readonly ApplicationDbContext _context;
        public ChauffeurService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<ChauffeurDto>> GetAllAsync() =>
            await _context.Chauffeurs.Select(c => new ChauffeurDto
            {
                Nom = c.Nom,
                Telephone = c.Telephone
            }).ToListAsync();

        public async Task<ChauffeurDto?> GetByIdAsync(string id)
        {
            var c = await _context.Chauffeurs.FindAsync(id);
            return c == null ? null : new ChauffeurDto
            {
                Nom = c.Nom,
                Telephone = c.Telephone
            };
        }

        public async Task<ChauffeurDto> CreateAsync(ChauffeurCreateDto dto)
        {
            var c = new Chauffeur
            {
                Nom = dto.Nom,
                Telephone = dto.Telephone
            };
            _context.Chauffeurs.Add(c);
            await _context.SaveChangesAsync();
            return new ChauffeurDto { Nom = c.Nom, Telephone = c.Telephone };
        }

        public async Task<bool> UpdateAsync(string id, ChauffeurCreateDto dto)
        {
            var c = await _context.Chauffeurs.FindAsync(id);
            if (c == null) return false;

            c.Nom = dto.Nom;
            c.Telephone = dto.Telephone;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var c = await _context.Chauffeurs.FindAsync(id);
            if (c == null) return false;

            _context.Chauffeurs.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
