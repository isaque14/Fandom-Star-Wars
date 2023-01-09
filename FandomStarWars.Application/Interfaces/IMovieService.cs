using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Interfaces
{
    public interface IMovieService
    {
        Task<GenericResponse> GetAllAsync();
        Task<GenericResponse> GetByIdAsync(int id);
        Task<GenericResponse> GetByNameAsync(string name);
        Task<GenericResponse> CreateAsync(MovieDTO filmDTO);
        Task<GenericResponse> UpdateAsync(MovieDTO filmDTO);
        Task<GenericResponse> DeleteAsync(int id);

        Task InsertFilmsExternalApiIntoDataBase();
        Task<MovieDTO> GetFilmInExternalApiByIdAsync(int id);
        Task<IEnumerable<MovieDTO>> GetAllFilmsInExternalApiAsync();
    }
}
