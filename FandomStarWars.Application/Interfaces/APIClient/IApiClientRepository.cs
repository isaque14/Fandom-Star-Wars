using FandomStarWars.Application.DTO_s;
using Refit;
using static FandomStarWars.Application.DTO_s.CharacterDTO;

namespace FandomStarWars.Application.Interfaces.APIClient
{
    public interface IApiClientRepository
    {
        [Get("/people")]
        Task<Root> GetAllPersonsAsync();

        [Get("/people/{id}")]
        Task<CharacterDTO> GetById(int id);

    }
}
