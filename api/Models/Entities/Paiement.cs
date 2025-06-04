namespace Transporteo.Models.Entities
{
    public class Paiement: BaseEntity
    {
        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; } = default!;
        public decimal Montant { get; set; }
        public string Mode { get; set; } = string.Empty; // Ex: 'MobileMoney', 'Carte', etc.
        public DateTime DatePaiement { get; set; }
        public bool EstValide { get; set; }
    }
}
