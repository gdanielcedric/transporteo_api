namespace Transporteo.Models.Entities
{
    public class Ligne: BaseEntity
    {
        public string VilleDepart { get; set; } = string.Empty;
        public string VilleArrivee { get; set; } = string.Empty;
    }
}
