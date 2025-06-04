using Microsoft.EntityFrameworkCore;
using System;
using Transporteo.Data;
using Transporteo.DTOs.Bus;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class BusService : IBusService
    {
        private readonly ApplicationDbContext _context;
        public BusService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<BusDto>> GetAllAsync() =>
            await _context.Buses.Select(b => new BusDto
            {
                Marque = b.Marque,
                Matricule = b.Matricule,
                NombreDePlaces = b.NombreDePlaces
            }).ToListAsync();

        public async Task<BusDto?> GetByIdAsync(string id)
        {
            var b = await _context.Buses.FindAsync(id);
            return b == null ? null : new BusDto
            {
                Marque = b.Marque,
                Matricule = b.Matricule,
                NombreDePlaces = b.NombreDePlaces
            };
        }

        public async Task<BusDto> CreateAsync(BusCreateDto dto)
        {
            var b = new Bus
            {
                Marque = dto.Marque,
                Matricule = dto.Matricule,
                NombreDePlaces = dto.NombreDePlaces
            };
            _context.Buses.Add(b);
            await _context.SaveChangesAsync();
            return new BusDto { Marque = b.Marque, Matricule = b.Matricule, NombreDePlaces = b.NombreDePlaces };
        }

        public async Task<bool> UpdateAsync(string id, BusCreateDto dto)
        {
            var b = await _context.Buses.FindAsync(id);
            if (b == null) return false;
            b.Marque = dto.Marque;
            b.Matricule = dto.Matricule;
            b.NombreDePlaces = dto.NombreDePlaces;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var b = await _context.Buses.FindAsync(id);
            if (b == null) return false;
            _context.Buses.Remove(b);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
