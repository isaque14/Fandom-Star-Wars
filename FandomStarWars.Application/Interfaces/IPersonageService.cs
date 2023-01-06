using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Interfaces
{
    public interface IPersonageService
    {
        Task<IEnumerable<PersonageDTO>> GetAllAsync();

        Task<PersonageDTO> GetByIdAsync(int id);

        Task<PersonageDTO> GetByNameAsync(string name);

        Task CreateAsync(PersonageDTO personageDTO);

        Task<GenericResponse> UpdateAsync(PersonageDTO personageDTO);

        Task DeleteAsync(int id);

        Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync();

        Task InsertPersonagesExternalApiIntoDataBase();

        Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id);
    }
}
