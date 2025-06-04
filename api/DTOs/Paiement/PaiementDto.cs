namespace Transporteo.DTOs.Paiement
{
    public class PaiementDto
    {
        public string ReservationId { get; set; }
        public decimal Montant { get; set; }
        public string Mode { get; set; } = string.Empty;
        public DateTime DatePaiement { get; set; }
        public bool EstValide { get; set; }
    }
}
