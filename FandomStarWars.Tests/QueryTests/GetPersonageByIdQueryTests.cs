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
    public class GetPersonageByIdQueryTests
    {
        private readonly IMapper _mapper;
        private readonly GetPersonageByIdQueryHandler _queryGetPersonageByID;

        public GetPersonageByIdQueryTests()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _queryGetPersonageByID = new GetPersonageByIdQueryHandler(new FakePersonageRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler valid return personages By Id")]
        public void QueryHandler_ValidQuery_ReturnPersonageByID()
        {
            var id = 1;
            GenericResponse response = _queryGetPersonageByID.Handle(new GetPersonageByIdQueryRequest(id), new CancellationToken()).Result;
            var personageDTO = response.Object as PersonageDTO;
            Assert.Equal(id, personageDTO.Id);
        }
    }
}
