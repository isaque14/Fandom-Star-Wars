using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;

namespace FandomStarWars.Tests.Services
{
    internal class FakePersonageService : IPersonageService
    {
        public Task<GenericResponse> CreateAsync(PersonageDTO personageDTO)
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests",
                Object = personageDTO
            });
        }

        public Task<GenericResponse> DeleteAsync(int id)
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests"
            });
        }

        public Task<GenericResponse> GetAllAsync()
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests"
            });
        }

        public Task<IEnumerable<PersonageDTO>> GetAllPersonagesInExternalApiAsync()
        {
            var personagesDTOMock = new List<PersonageDTO>();
            personagesDTOMock.Add(new PersonageDTO
            {
                Name = "teste",
                Height = "164",
                Mass = "70",
                HairColor = "black",
                SkinColor = "black",
                EyeColor = "green",
                BirthYear = "data",
                Gender = "male",
                Homeworld = "earth"
            });

            return Task.FromResult(personagesDTOMock as IEnumerable<PersonageDTO>);
        }

        public Task<GenericResponse> GetByIdAsync(int id)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByNameAsync(string name)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<PersonageDTO> GetPersonageInExternalApiByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertPersonagesExternalApiIntoDataBase()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> UpdateAsync(PersonageDTO personageDTO)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }
    }
}
