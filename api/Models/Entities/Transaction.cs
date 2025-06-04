namespace Transporteo.Models.Entities
{
    public class Transaction
    {
        public required string TicketId { get; set; }
        public required string PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Ticket Ticket { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

}
