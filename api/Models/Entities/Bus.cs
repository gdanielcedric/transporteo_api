namespace Transporteo.Models.Entities
{
    public class Bus: BaseEntity
    {
        public string Marque { get; set; } = string.Empty;
        public string Matricule { get; set; } = string.Empty;
        public int NombreDePlaces { get; set; }
    }

}
