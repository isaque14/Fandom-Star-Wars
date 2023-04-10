using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.ExternalApi.Querys;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Interfaces.APIClient;
using FandomStarWars.Domain.Entities;
using MediatR;
using static FandomStarWars.Application.DTO_s.MovieDataExternalApiDTO;

namespace FandomStarWars.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPersonageService _personageService;
        private readonly IExternalApiService _externalApiService;

        public MovieService(IMapper mapper, IMediator mediator, IPersonageService personageService, IExternalApiService externalApiService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _personageService = personageService;
            _externalApiService = externalApiService;
        }

        public async Task<GenericResponse> GetAllAsync()
        {
            var getMoviesQuery = new GetMoviesQueryRequest();
            if (getMoviesQuery is null) 
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(getMoviesQuery);
            return response;
        }

        public async Task<GenericResponse> GetByIdAsync(int id)
        {
            var getMovieQuery = new GetMovieByIdQueryRequest(id);
            if (getMovieQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(getMovieQuery);
            return response;
        }

        public async Task<GenericResponse> GetByNameAsync(string name)
        {
            var getMovie = new GetMovieByNameQueryRequest(name);
            if (getMovie is null) 
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(getMovie);
            return response;
        }

        public async Task<GenericResponse> CreateAsync(MovieDTO movieDTO)
        {
            var createMovieCommand = _mapper.Map<CreateMovieCommandRequest>(movieDTO);
            var response = await _mediator.Send(createMovieCommand);
            return response;
        }

        public async Task<GenericResponse> UpdateAsync(MovieDTO movieDTO)
        {
            var updateMovieCommand = _mapper.Map<UpdateMovieCommandRequest>(movieDTO);
            var response = await _mediator.Send(updateMovieCommand);
            return response;
        }

        public async Task<GenericResponse> DeleteAsync(int id)
        {
            var deleteMovie = new DeleteMovieCommandRequest(id);
            var response = await _mediator.Send(deleteMovie);
            return response;
        }
    }
}
