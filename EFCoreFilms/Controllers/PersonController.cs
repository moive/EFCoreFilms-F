using EFCoreFilms.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            return await context.Persons
                .Include(p => p.SendMessages)
                .Include(p => p.ReceivedMessages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
