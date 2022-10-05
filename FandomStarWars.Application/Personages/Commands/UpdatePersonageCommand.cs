using FandomStarWars.Application.Personages.Commands.Base;

namespace FandomStarWars.Application.Personages.Commands
{
    public class UpdatePersonageCommand : PersonageCommand
    {
        public int Id { get; set; }
    }
}
