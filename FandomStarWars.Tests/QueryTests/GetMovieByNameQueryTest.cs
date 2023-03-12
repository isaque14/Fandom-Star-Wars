using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Handlers.Querys;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.QueryTests
{
    public class GetMovieByNameQueryTest
    {
        private readonly IMapper _mapper;
        private readonly GetMovieByNameQueryRequestHandler _queryGetMovieByName;

        public GetMovieByNameQueryTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _queryGetMovieByName = new GetMovieByNameQueryRequestHandler(_mapper, new FakeMovieRepository());
        }

        [Fact(DisplayName = "Handler Query valid return movie By ID")]
        public void QueryHandler_ValidQuery_ReturnMovieByID()
        {
            var title = "Vingadores";
            GenericResponse response = _queryGetMovieByName.Handle(new GetMovieByNameQueryRequest(title), new CancellationToken()).Result;
            var movieDTO = response.Object as MovieDTO;
            Assert.Equal(title, movieDTO.Title);
        }
    }
}
