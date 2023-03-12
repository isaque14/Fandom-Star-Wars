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
    public class GetMovieByIdQueryTest
    {
        private readonly IMapper _mapper;
        private readonly GetMovieByIdQueryRequestHandler _queryGetMovieByID;

        public GetMovieByIdQueryTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _queryGetMovieByID = new GetMovieByIdQueryRequestHandler(_mapper, new FakeMovieRepository());
        }

        [Fact(DisplayName = "Handler Query valid return movie By ID")]
        public void QueryHandler_ValidQuery_ReturnMovieByID()
        {
            var id = 3;
            GenericResponse response = _queryGetMovieByID.Handle(new GetMovieByIdQueryRequest(id), new CancellationToken()).Result;
            var movieDTO = response.Object as MovieDTO;
            Assert.Equal(id, movieDTO.Id);
        }
    }
}
