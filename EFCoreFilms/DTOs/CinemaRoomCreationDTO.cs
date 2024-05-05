using EFCoreFilms.entities;

namespace EFCoreFilms.DTOs
{
    public class CinemaRoomCreationDTO
    {

        public int Id { get; set; }
        public decimal Price { get; set; }
        public CinemaType CinemaType { get; set; }
    }
}
