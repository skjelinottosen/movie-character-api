using AutoMapper;
using Task13_SkjelinOttosen.API.DTOs.ActoDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorDto>();
        }
    }
}
