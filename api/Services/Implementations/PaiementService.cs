using api.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.DTOs.Paiement;
using Transporteo.Models.Entities;

namespace Transporteo.Services.Implementations
{
    public class PaiementService : IPaiementService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaiementService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaiementDto> CreateAsync(PaiementCreateDto dto)
        {
            var paiement = _mapper.Map<Paiement>(dto);
            paiement.DatePaiement = DateTime.UtcNow;
            paiement.EstValide = true;

            _context.Paiements.Add(paiement);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaiementDto>(paiement);
        }

        public async Task<IEnumerable<PaiementDto>> GetAllAsync()
        {
            var paiements = await _context.Paiements.ToListAsync();
            return _mapper.Map<IEnumerable<PaiementDto>>(paiements);
        }

        public async Task<IEnumerable<PaiementDto>> GetByReservationIdAsync(string reservationId)
        {
            var paiements = await _context.Paiements
                .Where(p => p.ReservationId == reservationId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PaiementDto>>(paiements);
        }
    }
}
