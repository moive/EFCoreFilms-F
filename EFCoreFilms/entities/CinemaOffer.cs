namespace EFCoreFilms.entities
{
    public class CinemaOffer
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal DiscountPercentage { get; set; }
        public int CinemaId { get; set; }
    }
}
