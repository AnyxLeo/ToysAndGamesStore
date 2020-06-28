using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGamesStore.Interfaces;
using ToysAndGamesStore.Interfaces.Repositories;
using ToysAndGamesStore.Models;

namespace ToysAndGamesStore.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DataBaseContext _context;
        public GameRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Game model)
        {
            _context.Games.Add(model);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var current = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (current == null)
                return false;

            _context.Remove(current);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetAsync(int id) => await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        public async Task<bool> UpdateAsync(Game model)
        {
            var current =await  _context.Games.FirstOrDefaultAsync(g => g.Id == model.Id);

            if (current == null)
                return false;

            current.AgeRestriction = model.AgeRestriction;
            current.Company = model.Company;
            current.Description = model.Description;
            current.Name = model.Name;
            current.Price = model.Price;
            _context.Update(current);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
