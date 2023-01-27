using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Querys;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Querys
{
    public class GetMovieByIdQueryRequestHandler : IRequestHandler<GetMovieByIdQueryRequest, GenericResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;

        public GetMovieByIdQueryRequestHandler(IMapper mapper, IMovieRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GenericResponse> Handle(GetMovieByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var movieEntity = await _repository.GetByIdAsync(request.Id);
                if (movieEntity is null)
                    throw new Exception("Movie Not Found");

                var movieDTO = _mapper.Map<MovieDTO>(movieEntity);
                movieDTO.PersonagesDTO = _mapper.Map<IEnumerable<PersonageDTO>>(movieEntity.Personages);
                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained Movie",
                    Object = movieDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = $"{e.Message}"
                };
            }
        }
    }
}
