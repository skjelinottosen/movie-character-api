using AutoMapper;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.DTOs.FranchiseDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class FranchiseProfile : Profile 
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseDto>();
            CreateMap<Franchise, FranchiseAllMoviesDto>().ForMember(f => f.Movies, opt => opt.MapFrom(f => f.HasMovies.ToList()));
            CreateMap<Franchise, FranchiseAllCharactersDto>().ForMember(f => f.Characters, opt => opt.MapFrom(f => f.HasMovies.SelectMany(m => m.HasCharacters.Select(mc => mc.Character).ToList())));
        }
    }
}
