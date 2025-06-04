namespace Transporteo.DTOs.Bus
{
    public class BusCreateDto
    {
        public string Marque { get; set; } = string.Empty;
        public string Matricule { get; set; } = string.Empty;
        public int NombreDePlaces { get; set; }
    }
}
