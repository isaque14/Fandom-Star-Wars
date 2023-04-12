using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Querys
{
    public class GetMoviesQueryRequestHandler : IRequestHandler<GetMoviesQueryRequest, GenericResponse>
    {
        private readonly IMovieRepository _repository;

        public GetMoviesQueryRequestHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenericResponse> Handle(GetMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var moviesEntity = await _repository.GetAllAsync();
                                
                return new GenericResponse
                {
                    IsSuccessful = moviesEntity is not null ? true : false,
                    Message = moviesEntity is not null ? "Successfully obtained Movies" : "Not found Movies",
                    Object = moviesEntity
                };

            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Error " + e.Message
                };
            }
        }
    }
}
