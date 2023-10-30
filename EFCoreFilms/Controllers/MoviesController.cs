using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await context.Films
                .Include(x => x.Genders.OrderByDescending(g => g.Name))
                .Include(x => x.cinemaRooms).ThenInclude(y => y.Cinema)
                .Include(x => x.FilmsActors.Where(z => z.Actor.BirthDate.Value.Year >= 1980)).ThenInclude(y => y.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null) { return NotFound(); }

            var movieDTO = mapper.Map<MovieDTO>(movie);
            movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

            return movieDTO;
        }

        [HttpGet("withProjectTo/{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetProjectTo(int id)
        {
            var movie = await context.Films
                .ProjectTo<MovieDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null) { return NotFound(); }

            movie.Cinemas = movie.Cinemas.DistinctBy(x => x.Id).ToList();

            return movie;
        }
    }
}
