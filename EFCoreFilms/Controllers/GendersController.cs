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
            return await context.Genders.OrderBy(g => g.Name).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Gender>> Get(int id)
        {
            var gender = await context.Genders.FirstOrDefaultAsync(g => g.Identifier == id);
            if (gender is null)
            {
                return NotFound();
            }
            return gender;
        }

        [HttpGet("first")]
        public async Task<ActionResult<Gender>> First()
        {
            var gender = await context.Genders.FirstOrDefaultAsync(g => g.Name.StartsWith("C"));

            if (gender is null)
            {
                return NotFound();
            }
            return gender;
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Gender>> Filter(string name)
        {
            return await context.Genders
                .Where(g => g.Name.Contains(name))
                .OrderByDescending(g => g.Name)
                .ToListAsync();
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<Gender>>> GetPagination(int page = 1)
        {
            var quantityRecordsByPage = 2;
            var gender = await context.Genders
                .Skip((page - 1) * quantityRecordsByPage)
                .Take(quantityRecordsByPage)
                .ToListAsync();
            return gender;
        }
    }
}
