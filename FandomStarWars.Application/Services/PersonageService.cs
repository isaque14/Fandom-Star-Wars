using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.CQRS.Personages.Requests.Commands;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
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

            return new PersonageDTO{ 
                Name = personageApi.Name, 
                Height = personageApi.Height, 
                Mass = personageApi.Mass, 
                HairColor = personageApi.Hair_Color, 
                SkinColor = personageApi.Skin_Color, 
                EyeColor = personageApi.Eye_Color, 
                BirthYear = personageApi.Birth_Year, 
                Gender = personageApi.Gender, 
                Homeworld = personageApi.Homeworld, 
                Created = personageApi.Created, 
                Edited = personageApi.Edited
                };
        }

        public async Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync()
        {
            int numberPage = 1;
            var getPersonageExternalApi = new GetPersonagesExternalApiByPageQuery(numberPage);

            if (getPersonageExternalApi == null)
                throw new Exception($"API could not be loaded.");

            var personagesAPi = await _mediator.Send(getPersonageExternalApi);
            
            var personagesDTO = new List<PersonageDTO>();

            var nextElement = true;
            while (nextElement)
            {
                foreach (var p in personagesAPi.Results)
                {
                    int idPlanet = 0;
                    var lastSegment = new Uri(p.Homeworld).Segments.Last();

                    int.TryParse(lastSegment.Remove(lastSegment.Length - 1), out idPlanet);

                    var getPlanetExternalApiByIdQuery = new GetPlanetExternalApiByIdQuery(idPlanet);
                    var planet = await _mediator.Send(getPlanetExternalApiByIdQuery);

                    personagesDTO.Add(new PersonageDTO{ 
                        Name = p.Name,
                        Height = p.Height,
                        Mass = p.Mass,
                        HairColor = p.Hair_Color,
                        SkinColor = p.Skin_Color,
                        EyeColor = p.Eye_Color,
                        BirthYear = p.Birth_Year,
                        Gender = p.Gender,
                        Homeworld = planet.Name,
                        //Convert.ToDateTime(p.Created),
                        //Convert.ToDateTime(p.Edited)
                        Created = p.Created,
                        Edited = p.Edited
                    });
                }

                numberPage++;

                var nextPage = new GetPersonagesExternalApiByPageQuery(numberPage);

                if (nextPage == null)
                    throw new Exception($"API could not be loaded.");

                if (personagesAPi.Next is null) 
                    nextElement = false;
                
                else
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

        public async Task<GenericResponse> GetAllAsync()
        {
            var personageQuery = new GetPersonagesQueryRequest();

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> GetByIdAsync(int id)
        {
            var personageQuery = new GetPersonageByIdQueryRequest(id);

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> GetByNameAsync(string name)
        {
            var personageQuery = new GetPersonageByNameQueryRequest(name);

            if (personageQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(personageQuery);
            return response;
        }

        public async Task<GenericResponse> CreateAsync(PersonageDTO personageDTO)
        {
            var CreatePersonageCommand = _mapper.Map<CreatePersonageCommandRequest>(personageDTO); 
            
            var response = await _mediator.Send(CreatePersonageCommand);
            return response;
        }

        public async Task<GenericResponse> UpdateAsync(PersonageDTO personageDTO)
        {
            var UpdatePersonageCommand = _mapper.Map<UpdatePersonageCommandRequest>(personageDTO);
            var response = await _mediator.Send(UpdatePersonageCommand);
            return response;
        }

        public async Task<GenericResponse> DeleteAsync(int id)
        {
            var deletePersonageCommand = new DeletePersonageCommandRequest(id);

            if (deletePersonageCommand is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(deletePersonageCommand);
            return response;
        }
    }
}
