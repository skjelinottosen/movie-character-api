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
        }
    }
}
