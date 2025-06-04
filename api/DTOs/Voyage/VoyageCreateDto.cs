namespace Transporteo.DTOs.Voyage
{
    public class VoyageCreateDto
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }

}
