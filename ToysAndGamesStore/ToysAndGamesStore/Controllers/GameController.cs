
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToysAndGamesStore.Interfaces.Repositories;
using ToysAndGamesStore.Models;

namespace ToysAndGamesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;
        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Game game)
        {
            var succes = await _repository.CreateAsync(game);

            if (succes <= 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await _repository.GetAsync(id);

            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> Update(Game model)
        {
            var succes = await _repository.UpdateAsync(model);

            if (!succes)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var succes = await _repository.DeleteAsync(id);

            if (!succes)
                return NotFound();

            return Ok();
        }

        [HttpGet("all")]
        public async Task<ActionResult<Game>> Get()
        {
            var games = await _repository.GetAllAsync();

            if (games == null)
                return NotFound();

            return Ok(games);
        }
    }
}