using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Application.Personages.Querys;

namespace FandomStarWars.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<PersonageDTO, CreatePersonageCommandRequest>();
            CreateMap<PersonageDTO, UpdatePersonageCommandRequest>();

            CreateMap<FilmDTO, CreateFilmCommandRequest>();
        }
    }
}
