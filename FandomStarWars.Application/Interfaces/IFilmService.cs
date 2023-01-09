using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Interfaces
{
    public interface IFilmService
    {
        Task<GenericResponse> GetAllAsync();
        Task<GenericResponse> GetByIdAsync(int id);
        Task<GenericResponse> GetByNameAsync(string name);
        Task<GenericResponse> CreateAsync(FilmDTO filmDTO);
        Task<GenericResponse> UpdateAsync(FilmDTO filmDTO);
        Task<GenericResponse> DeleteAsync(int id);

        Task InsertFilmsExternalApiIntoDataBase();
        Task<FilmDTO> GetFilmInExternalApiByIdAsync(int id);
        Task<IEnumerable<FilmDTO>> GetAllFilmsInExternalApiAsync();
    }
}
