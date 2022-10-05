using FandomStarWars.Domain.Entities;
using MediatR;

namespace FandomStarWars.Application.Personages.Commands
{
    public class DeletePersonageCommand : IRequest<Personage>
    {
        public int Id { get; set; }
        public DeletePersonageCommand(int id)
        {
            Id = Id;
        }
    }
}
