namespace Transporteo.DTOs.Voyage
{
    public class VoyageDto
    {
        public string LigneId { get; set; }
        public string BusId { get; set; }
        public string ChauffeurId { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }

}
