using EFCoreFilms.entities;

namespace EFCoreFilms.DTOs
{
    public class CinemaRoomCreationDTO
    {
        public decimal Price { get; set; }
        public CinemaType CinemaType { get; set; }
    }
}
