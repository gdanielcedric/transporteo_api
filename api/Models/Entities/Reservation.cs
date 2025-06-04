namespace Transporteo.Models.Entities
{
    public class Reservation: BaseEntity
    {
        public string VoyageId { get; set; }
        public Voyage Voyage { get; set; } = default!;
        public string UtilisateurId { get; set; }
        public int NombrePlaces { get; set; }
        public DateTime DateReservation { get; set; }
    }
}
