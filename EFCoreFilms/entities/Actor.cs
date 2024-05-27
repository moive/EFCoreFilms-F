using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    public class Actor
    {
        public int Id { get; set; }
        private string _name;
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = string.Join(' ',
                    value.Split(' ')
                    .Select(x=> x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }
        public string Bio { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        public List<FilmActor> FilmsActors { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (!BirthDate.HasValue)
                {
                    return null;
                }

                var birthDate = BirthDate.Value;
                var age = DateTime.Today.Year - birthDate.Year;
                if(new DateTime(DateTime.Today.Year, birthDate.Month, birthDate.Day) > DateTime.Today){
                    age--;
                }
                return age;
            }
        }

        public Address Address { get; set; }
    }
}
