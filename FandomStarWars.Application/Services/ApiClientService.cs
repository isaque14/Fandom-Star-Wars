using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;

        public ApiClientService(IMediator mediator, IPersonageService personageService)
        {
            _mediator = mediator;
            _personageService = personageService;
        }

        public async Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id)
        {
            var getPersonage = new GetPersonageExternalApiByIdQuery(id);

            if (getPersonage == null)
                throw new Exception($"API could not be loaded.");

            var personageApi = await _mediator.Send(getPersonage);

            return new PersonageDTO
            {
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

                    personagesDTO.Add(new PersonageDTO
                    {
                        Name = p.Name,
                        Height = p.Height,
                        Mass = p.Mass,
                        HairColor = p.Hair_Color,
                        SkinColor = p.Skin_Color,
                        EyeColor = p.Eye_Color,
                        BirthYear = p.Birth_Year,
                        Gender = p.Gender,
                        Homeworld = planet.Name,
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
                GenericResponse response = _personageService.GetByNameAsync(personage.Name).Result;

                if (!response.IsSuccessful)
                    await _personageService.CreateAsync(personage);
            }
        }
    }
}
