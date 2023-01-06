using AutoMapper;
using FandomStarWars.Application.CQRS.Films.Requests.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<PersonageDTO, CreatePersonageCommandRequest>().ReverseMap();
            CreateMap<PersonageDTO, UpdatePersonageCommandRequest>().ReverseMap();

            CreateMap<FilmDTO, CreateFilmCommandRequest>();
        }
    }
}
