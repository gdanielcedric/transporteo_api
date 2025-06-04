using System.ComponentModel.DataAnnotations;

namespace Transporteo.DTOs.Reservation
{
    public class ReservationCreateDto
    {
        [Required]
        public string UtilisateurId { get; set; }

        [Range(1, int.MaxValue)]
        public int NombrePlaces { get; set; }
    }
}
