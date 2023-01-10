using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Commands
{
    public class UpdateMovieCommandRequestHandler : IRequestHandler<UpdateMovieCommandRequest, GenericResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieCommandRequestHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<GenericResponse> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var movieEntity = await _movieRepository.GetByIdAsync(request.Id);
                if (movieEntity is null) throw new Exception("Movie Not Found By Id");

                var movieDTO = _mapper.Map<MovieDTO>(movieEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully obtained movie",
                    Object = movieDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = e.Message
                };
            }
        }
    }
}
