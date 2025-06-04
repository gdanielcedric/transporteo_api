using AutoMapper;    // Remplace également ici
using Transporteo.DTOs.Paiement;
using Transporteo.DTOs.Reservation;
using Transporteo.Models.Entities;

namespace Transporteo.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Paiement
            CreateMap<Paiement, PaiementDto>();
            CreateMap<PaiementCreateDto, Paiement>();

            // Reservation
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationCreateDto, Reservation>();

            // Ajoute ici les autres mappings si nécessaire plus tard
        }
    }

}
