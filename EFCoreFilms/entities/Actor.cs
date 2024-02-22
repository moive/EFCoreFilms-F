using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        public List<FilmActor> FilmsActors { get; set; }
    }
}
