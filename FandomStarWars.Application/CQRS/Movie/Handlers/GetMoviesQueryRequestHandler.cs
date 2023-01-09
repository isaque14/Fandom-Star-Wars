using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Films.Requests.Querys;
using MediatR;

namespace FandomStarWars.Application.CQRS.Films.Handlers
{
    public class GetMoviesQueryRequestHandler : IRequestHandler<GetMoviesQueryRequest, GenericResponse>
    {
        private readonly IMapper _mapper;

        public GetMoviesQueryRequestHandler(IMapper mapper)
        {
            mapper = mapper;
        }

        public Task<GenericResponse> Handle(GetMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
