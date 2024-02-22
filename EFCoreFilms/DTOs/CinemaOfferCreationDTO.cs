using System.ComponentModel.DataAnnotations;

namespace EFCoreFilms.DTOs
{
    public class CinemaOfferCreationDTO
    {
        [Range(1, 100)]
        public double DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
