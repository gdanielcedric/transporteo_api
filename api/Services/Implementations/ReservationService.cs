using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Transporteo.Data;
using Transporteo.DTOs.Reservation;
using Transporteo.Models.Entities;
using Transporteo.Services.Interfaces;

namespace Transporteo.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationDto> CreateAsync(ReservationCreateDto dto)
        {
            var reservation = _mapper.Map<Reservation>(dto);
            reservation.DateReservation = DateTime.UtcNow;

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto?> GetByIdAsync(string id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return reservation == null ? null : _mapper.Map<ReservationDto>(reservation);
        }

        public async Task DeleteAsync(string id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ReservationStatDto>> GetStatsAsync()
        {
            return await _context.Reservations
                .GroupBy(r => new { r.DateReservation.Year, r.DateReservation.Month })
                .Select(g => new ReservationStatDto
                {
                    Annee = g.Key.Year,
                    Mois = g.Key.Month,
                    TotalReservations = g.Count(),
                    TotalPlaces = g.Sum(r => r.NombrePlaces)
                })
                .OrderByDescending(r => r.Annee)
                .ThenByDescending(r => r.Mois)
                .ToListAsync();
        }

    }
}
