using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFilms.entities
{
    [NotMapped]
    public class Address
    {
        public string Street { get; set; }
        public string Province{ get; set; }
        public string Country { get; set; }
    }
}
