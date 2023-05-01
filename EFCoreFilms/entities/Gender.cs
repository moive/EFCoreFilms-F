using System.ComponentModel.DataAnnotations;

namespace EFCoreFilms.entities
{
    public class Gender
    {
        //[Key]
        public int Identifier { get; set; }

        //[StringLength(150)]
        //[MaxLength(150)]
        //[Required]
        public string Name { get; set; }
    }
}
