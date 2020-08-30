using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task13_SkjelinOttosen.API.DTOs;
using Task13_SkjelinOttosen.API.DTOs.CharacterDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>();

            CreateMap<Character, CharacterPlayedByActorsDto>().ForMember(c => c.Actors, opt => opt.MapFrom( c => c.AppearInMovies.Select(mc => mc.Actor).ToList()));
        }
    }
}
