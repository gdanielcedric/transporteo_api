namespace Transporteo.Models.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public required string Name { get; set; } // e.g., Orange Money, Moov, Wave
        public string Description { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }

}
