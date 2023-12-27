using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCoreFilms.entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public virtual CinemaOffer CinemaOffer { get; set; }
        public virtual HashSet<CinemaRoom> Cinemaroom { get; set; } // HashSet is not sortable data
    }
}
