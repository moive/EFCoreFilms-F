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
        }
    }
}
