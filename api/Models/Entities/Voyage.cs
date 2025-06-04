using System.Net.Sockets;

namespace Transporteo.Models.Entities
{
    public class Voyage : BaseEntity
    {
        public string LigneId { get; set; }
        public Ligne Ligne { get; set; }

        public string BusId { get; set; }
        public Bus Bus { get; set; }

        public string ChauffeurId { get; set; }
        public Chauffeur Chauffeur { get; set; }

        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }

        public int AvailableSeats { get; set; }
    }

}
