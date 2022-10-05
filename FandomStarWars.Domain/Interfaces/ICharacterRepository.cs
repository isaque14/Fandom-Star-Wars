using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetByIdAsync(int id);
        Task<Character> GetByNameAsync(string name);
        Task<Character> CreateAsync(Character character);   
        Task<Character> UpdateAsync(Character character);
        Task<Character> DeleteAsync(Character character);
    }
}
