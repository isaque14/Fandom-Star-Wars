using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Application.Personages.Commands;

namespace FandomStarWars.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<PersonageDTO, CreatePersonageCommand>();
            CreateMap<PersonageDTO, UpdatePersonageCommand>();

            CreateMap<FilmDTO, CreateFilmCommand>();
        }
    }
}
