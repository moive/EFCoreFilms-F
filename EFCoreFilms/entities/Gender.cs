using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    //[Table("TableGenders", Schema = "Films")]
    public class Gender
    {
        //[Key]
        public int Identifier { get; set; }

        //[StringLength(150)]
        //[MaxLength(150)]
        //[Required]
        //[Column("GenderName")]
        public string Name { get; set; }
        public virtual HashSet<Films> Films { get; set; }
    }
}
