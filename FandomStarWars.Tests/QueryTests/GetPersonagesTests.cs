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
    public class GetPersonagesTests
    {
        private readonly IMapper _mapper;
        private readonly GetPersonagesQueryHandler _queryGetPersonages;

        public GetPersonagesTests()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
           
            var provider = service.BuildServiceProvider();
            _queryGetPersonages = new GetPersonagesQueryHandler(new FakePersonageRepository(), _mapper);
        }

        [Fact(DisplayName = "Handler Query valid return all personages")]
        public void QueryHandler_ValidQuery_ReturnAllPersonages()
        {
            GenericResponse response = _queryGetPersonages.Handle(new GetPersonagesQueryRequest(), new CancellationToken()).Result;
            var personages = (List<PersonageDTO>) response.Object;
            Assert.Equal(4, personages.Count());
        }
    }
}
