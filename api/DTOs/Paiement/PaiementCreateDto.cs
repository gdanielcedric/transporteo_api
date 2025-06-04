using System.ComponentModel.DataAnnotations;

namespace Transporteo.DTOs.Paiement
{
    public class PaiementCreateDto
    {
        [Required] public string ReservationId { get; set; }
        [Required] public decimal Montant { get; set; }
        [Required] public string Mode { get; set; } = string.Empty;
    }
}
