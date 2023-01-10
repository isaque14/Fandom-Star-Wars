﻿using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.CQRS.Movies.Requests.Commands;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movies.Handlers.Commands
{
    public class DeleteMovieCommandRequestHandler : IRequestHandler<DeleteMovieCommandRequest, GenericResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;

        public DeleteMovieCommandRequestHandler(IMapper mapper, IMovieRepository repository)
		{
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GenericResponse> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
        {
			try
			{
                var movieEntity = await _repository.GetByIdAsync(request.Id);
                if (movieEntity is null) throw new Exception("Movie Not found by id");

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
