using FandomStarWars.Application.DTO_s;

namespace FandomStarWars.Application.Interfaces
{
    public interface IApiClientService
    {
        public Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id);

        public Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync();

        public Task InsertPersonagesExternalApiIntoDataBase();

        public Task<IEnumerable<MovieDTO>> GetAllFilmsInExternalApiAsync();

        public Task InsertFilmsExternalApiIntoDataBase();
    }
}
