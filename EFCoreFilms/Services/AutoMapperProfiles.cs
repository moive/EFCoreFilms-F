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
        }
    }
}
