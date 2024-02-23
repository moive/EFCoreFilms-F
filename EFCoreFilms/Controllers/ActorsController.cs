using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            return await context.Actors
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ActorCreationDTO actorCreationDTO, int id)
        {
            var actorDB = await context.Actors.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (actorDB is null)
            {
                return NotFound();
            }

            actorDB = mapper.Map(actorCreationDTO, actorDB);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
