namespace EFCoreFilms.entities
{
    public class CinemaRoom
    {
        public int Id { get; set; }
        public CinemaType CinemaType { get; set; }
        public Decimal Price { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual HashSet<Films> Films { get; set; }
    }
}
