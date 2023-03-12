using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Handlers.Querys;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Mappings;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FandomStarWars.Tests.QueryTests
{
    public class GetMoviesQueryTest
    {
        private readonly IMapper _mapper;
        private readonly GetMoviesQueryRequestHandler _queryGetMovies;

        public GetMoviesQueryTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _queryGetMovies = new GetMoviesQueryRequestHandler(_mapper, new FakeMovieRepository());
        }

        [Fact(DisplayName = "Handler Query valid return all Movies")]
        public void QueryHandler_ValidQuery_ReturnAllMovies()
        {
            var allMovies = 3;
            GenericResponse response = _queryGetMovies.Handle(new GetMoviesQueryRequest(), new CancellationToken()).Result;
            var moviesDTO = (List<Movie>)response.Object;
            Assert.Equal(allMovies, moviesDTO.Count());
        }
    }
}
