namespace Transporteo.DTOs.Reservation
{
    public class ReservationDto
    {
        public string VoyageId { get; set; }
        public string? Trajet { get; set; } // optionnel, dérivé de Ligne si besoin

        public string UtilisateurId { get; set; }

        public int NombrePlaces { get; set; }

        public DateTime DateReservation { get; set; }
    }

}
