namespace Transporteo.Models.Entities
{
    public class Ticket: BaseEntity
    {
        public string UserId { get; set; }
        public string VoyageId { get; set; }
        public string? TransactionId { get; set; }

        public User User { get; set; }
        public Voyage Voyage { get; set; }
        public Transaction Transaction { get; set; }
    }

}
