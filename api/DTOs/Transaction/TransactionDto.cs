namespace Transporteo.DTOs.Transaction
{
    public class TransactionDto
    {
        public Guid TicketId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
