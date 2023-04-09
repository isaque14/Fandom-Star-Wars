using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Interfaces
{
    public interface IPersonageService
    {
        Task<GenericResponse> GetAllAsync();

        Task<GenericResponse> GetByIdAsync(int id);

        Task<GenericResponse> GetByNameAsync(string name);

        Task<GenericResponse> CreateAsync(PersonageDTO personageDTO);

        Task<GenericResponse> UpdateAsync(PersonageDTO personageDTO);

        Task<GenericResponse> DeleteAsync(int id);
    }
}
