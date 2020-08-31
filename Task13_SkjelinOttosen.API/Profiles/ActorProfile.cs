using AutoMapper;
using System.Linq;
using Task13_SkjelinOttosen.API.DTOs.ActoDTOs;
using Task13_SkjelinOttosen.API.DTOs.ActorDTOs;
using Task13_SkjelinOttosen.API.Profiles.ActorProfiles;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<Actor, ActorListViewDto>();
            CreateMap<Actor, ActorAllMoviesDto>().ForMember(a => a.Movies, opt => opt.MapFrom(a => a.ActInMovies.Select(m => m.Movie).ToList()));
        }
    }
}
