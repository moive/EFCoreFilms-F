using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Precision(precision: 9, scale: 2)]
        public decimal Price { get; set; }
    }
}
