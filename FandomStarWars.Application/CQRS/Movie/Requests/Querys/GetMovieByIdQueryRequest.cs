﻿using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace FandomStarWars.Application.CQRS.Movie.Requests.Querys
{
    public class GetMovieByIdQueryRequest : IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public GetMovieByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
