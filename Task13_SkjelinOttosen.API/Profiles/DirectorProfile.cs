using AutoMapper;
using Task13_SkjelinOttosen.API.DTOs;
using Task13_SkjelinOttosen.API.DTOs.DirectorDTOs;
using Task13_SkjelinOttosen.Model.Models;

namespace Task13_SkjelinOttosen.API.Profiles
{
    public class DirectorProfile : Profile
    {
     
        public DirectorProfile()
        {
            CreateMap<Director, DirectorDto>();
            CreateMap<Director, DirectorListViewDto>();
        }
    }
}
