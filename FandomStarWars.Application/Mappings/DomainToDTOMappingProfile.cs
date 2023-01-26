using AutoMapper;
using AutoMapper.Configuration;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Personage, PersonageDTO>().ReverseMap();
            CreateMap<Personage, PersonageDataExternalApiDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieDataExternalApiDTO>();
        }
    }
}
