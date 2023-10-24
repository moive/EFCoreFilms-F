using EFCoreFilms.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GendersController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GendersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Gender>> Get()
        {
            return await context.Genders.ToListAsync();
        }

        [HttpGet("first")]
        public async Task<Gender> First()
        {
            return await context.Genders.FirstAsync(g => g.Name.StartsWith("Z"));
        }
    }
}
