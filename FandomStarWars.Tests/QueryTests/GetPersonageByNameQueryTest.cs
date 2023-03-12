using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Personages.Handlers.Querys;
using FandomStarWars.Application.CQRS.Personages.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.QueryTests
{
    public class GetPersonageByNameQueryTest
    {
        private readonly IMapper _mapper;
        private readonly GetPersonageByNameQueryHandler _queryGetPersonageByName;

        public GetPersonageByNameQueryTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _queryGetPersonageByName = new GetPersonageByNameQueryHandler(new FakePersonageRepository(), _mapper);
        }

        [Fact(DisplayName = "Handler Query valid return all personages")]
        public void QueryHandler_ValidQuery_ReturnAllPersonages()
        {
            var name = "Isaque";
            GenericResponse response = _queryGetPersonageByName.Handle(new GetPersonageByNameQueryRequest(name), new CancellationToken()).Result;
            var personageDTO = response.Object as PersonageDTO;
            Assert.Equal(name, personageDTO.Name);
        }
    }
}
