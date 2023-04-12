using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Handlers.Querys;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Tests.Repositories;

namespace FandomStarWars.Tests.QueryTests
{
    public class GetMoviesQueryTest
    {
        private readonly GetMoviesQueryRequestHandler _queryGetMovies;

        public GetMoviesQueryTest()
        {
            _queryGetMovies = new GetMoviesQueryRequestHandler(new FakeMovieRepository());
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
