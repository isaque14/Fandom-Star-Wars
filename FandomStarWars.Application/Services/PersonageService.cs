using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Personages.Commands;
using FandomStarWars.Application.Personages.Handlers;
using FandomStarWars.Application.Personages.Querys;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Services
{
    public class PersonageService : IPersonageService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PersonageService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id)
        {
            var getPersonage = new GetPersonageExternalApiByIdQuery(id);

            if (getPersonage == null)
                throw new Exception($"API could not be loaded.");

            var personageApi = await _mediator.Send(getPersonage);

            return new PersonageDTO(
                personageApi.Name, 
                personageApi.Height, 
                personageApi.Mass, 
                personageApi.Hair_Color, 
                personageApi.Skin_Color, 
                personageApi.Eye_Color, 
                personageApi.Birth_Year, 
                personageApi.Gender, 
                personageApi.Homeworld, 
                personageApi.Created, 
                personageApi.Edited
                );
        }

        public async Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync()
        {
            int numberPage = 1;
            var getPersonageExternalApi = new GetPersonagesExternalApiByPageQuery(numberPage);

            if (getPersonageExternalApi == null)
                throw new Exception($"API could not be loaded.");

            var personagesAPi = await _mediator.Send(getPersonageExternalApi);
            
            var personagesDTO = new List<PersonageDTO>();

            
            while (personagesAPi.Next != null)
            {
                foreach (var p in personagesAPi.Results)
                {
                    int idPlanet = 0;
                    var lastSegment = new Uri(p.Homeworld).Segments.Last();

                    int.TryParse(lastSegment.Remove(lastSegment.Length - 1), out idPlanet);
                    
                    var getPlanetExternalApiByIdQuery = new GetPlanetExternalApiByIdQuery(idPlanet);
                    var planet = await _mediator.Send(getPlanetExternalApiByIdQuery);                  

                    personagesDTO.Add(new PersonageDTO(
                        p.Name,
                        p.Height,
                        p.Mass,
                        p.Hair_Color,
                        p.Skin_Color,
                        p.Eye_Color,
                        p.Birth_Year,
                        p.Gender,
                        planet.Name,
                        //Convert.ToDateTime(p.Created),
                        //Convert.ToDateTime(p.Edited)
                        p.Created,
                        p.Edited
                        ));
                }

                numberPage++;

                var nextPage = new GetPersonagesExternalApiByPageQuery(numberPage);

                if (nextPage == null)
                    throw new Exception($"API could not be loaded.");

                personagesAPi = await _mediator.Send(nextPage);
            }
            

            return personagesDTO as IEnumerable<PersonageDTO>;
        }

        public async Task InsertPersonagesExternalApiIntoDataBase()
        {
            var personagesDTO = await GetAllPersonagesInExternalApiAsync();

            foreach (var personage in personagesDTO)
            {
                await CreateAsync(personage);
            }
        }

        public async Task<IEnumerable<PersonageDTO>> GetAllAsync()
        {
            var personageQuery = new GetPersonagesQuery();

            if (personageQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personagesEntity = await _mediator.Send(personageQuery);

            return _mapper.Map<IEnumerable<PersonageDTO>>(personagesEntity);
        }

        public async Task<PersonageDTO> GetByIdAsync(int id)
        {
            var personageQuery = new GetPersonageByIdQuery(id);

            if (personageQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personageEntity = await _mediator.Send(personageQuery);
            return _mapper.Map<PersonageDTO>(personageEntity);
        }

        public async Task<PersonageDTO> GetByNameAsync(string name)
        {
            var personageQuery = new GetPersonageByNameQuery();

            if (personageQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personageEntity = await _mediator.Send(personageQuery);
            return _mapper.Map<PersonageDTO>(personageEntity);
        }

        public async Task CreateAsync(PersonageDTO personageDTO)
        {
            var CreatePersonageCommand = _mapper.Map<CreatePersonageCommand>(personageDTO); 
            await _mediator.Send(CreatePersonageCommand);
        }

        public async Task UpdateAsync(PersonageDTO personageDTO)
        {
            var UpdatePersonageCommand = _mapper.Map<UpdatePersonageCommand>(personageDTO);
            await _mediator.Send(UpdatePersonageCommand);
        }

        public async Task DeleteAsync(int id)
        {
            var deletePersonageCommand = new DeletePersonageCommand(id);

            if (deletePersonageCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(deletePersonageCommand);
        }
    }
}
