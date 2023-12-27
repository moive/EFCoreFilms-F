namespace EFCoreFilms.entities
{
    public class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public virtual Films Film { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
