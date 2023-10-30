using AutoMapper;
using EFCoreFilms.DTOs;
using EFCoreFilms.entities;

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
        }
    }
}
