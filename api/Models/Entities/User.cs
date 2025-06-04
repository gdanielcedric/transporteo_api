using System.Net.Sockets;

namespace Transporteo.Models.Entities
{
    public class User : BaseEntity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; } // Admin, Client

        public ICollection<Ticket> Tickets { get; set; }
    }

}
