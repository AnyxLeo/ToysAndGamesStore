using System.Collections.Generic;
using System.Threading.Tasks;
using ToysAndGamesStore.Models;

namespace ToysAndGamesStore.Interfaces.Repositories
{
    public interface IGameRepository
    {
        Task<int> CreateAsync(Game model);

        Task<Game> GetAsync(int id);

        Task<bool> UpdateAsync(Game model);

        Task<bool> DeleteAsync(int id);

        Task<List<Game>> GetAllAsync();
    }
}
