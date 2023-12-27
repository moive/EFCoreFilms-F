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

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var movie = context.Films
                .Select(p => new
                {
                    Id = p.Id,
                    Title = p.Title,
                    Genders = p.Genders.OrderByDescending(x => x.Name).Select(g => g.Name).ToList(),
                    Count = p.FilmsActors.Count(),
                    CinemasCount = p.cinemaRooms.Select(s => s.CinemaId).Distinct().Count()
                }).FirstOrDefault(x => x.Id == id);

            if (movie is null) { return NotFound(); }
            return Ok(movie);
        }

        //disadvantage: not very efficient
        [HttpGet("explicitLoading/{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetExplicit(int id)
        {
            var movie = await context.Films.AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            await context.Entry(movie).Collection(p => p.Genders).LoadAsync();

            var genderCount = await context.Entry(movie).Collection(p => p.Genders).Query().CountAsync();

            if (movie is null) { return NotFound(); };

            var movieDTO = mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        [HttpGet("lazyloading/{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetLazyLoading(int id)
        {
            var movies = await context.Films.AsTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (movies == null)
            {
                return NotFound();
            }

            var moviesDTO = mapper.Map<MovieDTO>(movies);
            moviesDTO.Cinemas = moviesDTO.Cinemas.DistinctBy(x => x.Id).ToList();
            return moviesDTO;
        }

        [HttpGet("GroupedByPremiere")]
        public async Task<ActionResult> GetGroupedByBillboard()
        {
            var groupedMovies = await context.Films.GroupBy(x => x.OnBillboard).Select(g => new
            {
                OnBillboard = g.Key,
                Count = g.Count(),
                Movies = g.ToList()
            }).ToListAsync();

            return Ok(groupedMovies);
        }

        [HttpGet("GroupedGenders")]
        public async Task<ActionResult> GetGroupedGenders()
        {
            var groupedMovies = await context.Films.GroupBy(p => p.Genders.Count()).Select(g => new
            {
                Count = g.Key,
                Title = g.Select(x => x.Title),
                Genders = g.Select(y => y.Genders).SelectMany(gen => gen).Select(gen => gen.Name).Distinct(),
            }).ToListAsync();

            return Ok(groupedMovies);
        }
    }
}