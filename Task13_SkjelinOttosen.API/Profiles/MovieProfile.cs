using AutoMapper;
using System.Linq;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    // Auto mapper class who maps data transfer objects to domain objects
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieListViewDto>();
            CreateMap<Movie, MovieCharactersActorsDto>()
                .ForMember(m => m.Characters, opt => opt
                .MapFrom(m => m.HasCharacters
                .SelectMany(mc => mc.Character.AppearInMovies
                .Select( mc => mc.Character).ToList())));
        }
    }
}
