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

        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Films>> Get(int id)
        {
            var movie = await context.Films
                .Include(x => x.Genders)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null) { return NotFound(); }

            return movie;
        }
    }
}
