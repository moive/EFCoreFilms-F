using AutoMapper;
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
                .Include(x => x.Genders)
                .Include(x => x.cinemaRooms).ThenInclude(y => y.Cinema)
                .Include(x => x.FilmsActors).ThenInclude(y => y.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null) { return NotFound(); }

            var movieDTO = mapper.Map<MovieDTO>(movie);
            movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

            return movieDTO;
        }
    }
}
