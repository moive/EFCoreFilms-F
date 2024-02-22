using AutoMapper;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreFilms.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTO>();

            CreateMap<Cinema, CinemaDTO>()
                .ForMember(dto => dto.Latitude, ent => ent.MapFrom(prop => prop.Location.Y))
                .ForMember(dto => dto.Longitude, ent => ent.MapFrom(prop => prop.Location.X));

            CreateMap<Gender, GenderDTO>();

            // without ProjectTo
            CreateMap<Films, MovieDTO>()
                .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(prop => prop.cinemaRooms.Select(x => x.Cinema)))
                .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.FilmsActors.Select(x => x.Actor)));


            // with ProjectTo
            //CreateMap<Films, MovieDTO>()
            //    .ForMember(dto => dto.Genders, ent => ent.MapFrom(prop => prop.Genders.OrderByDescending(g => g.Name)))
            //    .ForMember(dto => dto.Cinemas, ent => ent.MapFrom(prop => prop.cinemaRooms.Select(x => x.Cinema)))
            //    .ForMember(dto => dto.Actors, ent => ent.MapFrom(prop => prop.FilmsActors.Select(x => x.Actor)));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<CinemaCreationDTO, Cinema>()
                .ForMember(x => x.Location,
                    dto => dto.MapFrom(field =>
                        geometryFactory.CreatePoint(new Coordinate(field.Longitude, field.Latitude))));

            CreateMap<CinemaOfferCreationDTO, CinemaOffer>();
            CreateMap<CinemaRoomCreationDTO, CinemaRoom>();

            CreateMap<MovieCreationDTO, Films>()
                .ForMember(x => x.Genders,
                    dto => dto.MapFrom(field => field.Genders.Select(id => new Gender() { Identifier = id })))
                .ForMember(x => x.cinemaRooms,
                    dto => dto.MapFrom(field => field.CinemaRooms.Select(id => new CinemaRoom() { Id = id })));

            CreateMap<MovieActorCreationDTO, FilmActor>();
        }
    }
}
