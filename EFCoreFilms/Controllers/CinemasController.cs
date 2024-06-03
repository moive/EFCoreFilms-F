using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;
using EFCoreFilms.entities.keyless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreFilms.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinemasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("NoLocation")]
        public async Task<IEnumerable<CinemaNoLocation>> GetCinemaNoLocation()
        {
            return await context.Set<CinemaNoLocation>().ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> Get()
        {
            return await context.Cinemas.ProjectTo<CinemaDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("nearby")]
        public async Task<ActionResult> Get(double latitude, double longitude)
        {
            //lat: 18.483272, lng: -69.940143 // lat:18.469220 , lng: -69.939895
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
            var maximumDistanceInMeters = 2000;

            var cinema = await context.Cinemas
                .OrderBy(c => c.Location.Distance(myLocation))
                .Where(x => x.Location.IsWithinDistance(myLocation, maximumDistanceInMeters))
                .Select(c => new
                {
                    Name = c.Name,
                    Distance = Math.Round(c.Location.Distance(myLocation))
                }).ToListAsync();

            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var myLocation = geometryFactory.CreatePoint(new Coordinate(-69.896979, 18.476276));

            var cinema = new Cinema()
            {
                Name = "My Excelsius my currency",
                Location = myLocation,
                CinemaOffer = new CinemaOffer()
                {
                    DiscountPercentage = 5,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(7)
                },
                Cinemaroom = new HashSet<CinemaRoom>()
                {
                    new CinemaRoom()
                    {
                        Price = 200,
                        Currency = Currency.NewSun,
                        CinemaType = CinemaType.TwoDimensions
                    },
                    new CinemaRoom()
                    {
                        Price = 300,
                        Currency = Currency.Dollar,
                        CinemaType = CinemaType.ThreeDimensions
                    }
                }
            };

            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("withDTO")]
        public async Task<ActionResult> Post(CinemaCreationDTO cinemaCreationDTO) {
            var cinema = mapper.Map<Cinema>(cinemaCreationDTO);
            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var cinemaDB = await context.Cinemas.AsTracking()
                .Include(x => x.Cinemaroom)
                .Include(x => x.CinemaOffer)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(cinemaDB is null)
            {
                return NotFound();
            }
            cinemaDB.Location = null;
            return Ok(cinemaDB);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CinemaCreationDTO cinemaCreationDTO, int id)
        {
            var cinemaDB = await context.Cinemas.AsTracking()
                .Include(x=> x.Cinemaroom)
                .Include(y=> y.CinemaOffer)
                .FirstOrDefaultAsync(c=> c.Id == id);

            if(cinemaDB is null)
            {
                return NotFound();
            }

            cinemaDB = mapper.Map(cinemaCreationDTO, cinemaDB);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("cinemaOffer")]
        public async Task<ActionResult> PutOfferCinema(CinemaOffer cinemaOffer) {
            context.Update(cinemaOffer);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
