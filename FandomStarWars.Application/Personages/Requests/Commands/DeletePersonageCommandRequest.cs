using FandomStarWars.Application.Personages.Responses.Commands;
using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class DeletePersonageCommandRequest : IRequest<DeletePersonageCommandResponse>
    {
        public int Id { get; set; }
        public DeletePersonageCommandRequest(int id)
        {
            Id = Id;
        }
    }
}
