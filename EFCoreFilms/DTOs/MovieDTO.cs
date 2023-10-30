namespace EFCoreFilms.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GenderDTO> Genders { get; set; } = new List<GenderDTO>();
        public ICollection<CinemaDTO> Cinemas { get; set; }
        public ICollection<ActorDTO> Actors { get; set; }
    }
}
