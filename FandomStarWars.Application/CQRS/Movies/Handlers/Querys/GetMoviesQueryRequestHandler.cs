using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Querys
{
    public class GetMoviesQueryRequestHandler : IRequestHandler<GetMoviesQueryRequest, GenericResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;

        public GetMoviesQueryRequestHandler(IMapper mapper, IMovieRepository repository)
        {
            mapper = mapper;
            _repository = repository;
        }

        public async Task<GenericResponse> Handle(GetMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var moviesEntity = await _repository.GetAllAsync();
                var moviesDTO = new List<MovieDTO>();

                foreach (var movie in moviesEntity)
                {
                                        
                }

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = moviesEntity is not null ? "Successfully obtained Movies" : "Not found Movies",
                    Object = moviesDTO
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
