using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;
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
    }
}
