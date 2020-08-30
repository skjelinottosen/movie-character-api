using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.DTOs.MovieDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieCharactersActorsDto>().ForMember(m => m.Characters, opt => opt.MapFrom(m => m.HasCharacters.SelectMany(mc => mc.Character.AppearInMovies.Select( mc => mc.Character).ToList())));
        }
    }
}
