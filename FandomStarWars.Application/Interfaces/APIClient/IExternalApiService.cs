using Refit;
using static FandomStarWars.Application.DTO_s.PersonageDataExternalApiDTO;

namespace FandomStarWars.Application.Interfaces.APIClient
{
    public interface IExternalApiService
    {
        [Get("/people/?page={numberPage}")]
        Task<Root> GetPersonagesByPageAsync(int numberPage);
    }
}