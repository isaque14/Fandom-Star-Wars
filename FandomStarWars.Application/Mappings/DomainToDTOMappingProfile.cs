using AutoMapper;
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
           

            CreateMap<Film, FilmDTO>().ReverseMap();
            CreateMap<Film, FilmsDataExternalApiDTO>();
        }
    }
}
