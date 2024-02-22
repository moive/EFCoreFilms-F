namespace EFCoreFilms.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> Genders { get; set; }
        public List<int> CinemaRooms { get; set; }
        public List<MovieActorCreationDTO> FilmsActors { get; set; }
    }
}
