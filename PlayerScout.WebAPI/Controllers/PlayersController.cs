using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerScout.Data.Model;
using PlayerScout.Data.Repositories;

namespace PlayerScout.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IGenericRepository<Player> _playersRepository;

        public PlayersController(IGenericRepository<Player> playersRepository)
        {
            _playersRepository = playersRepository;
        }

        // GET api/players
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var players = await _playersRepository.AllAsync();
            if (players == null)
                return NotFound();

            return Ok(players);
        }

        // GET api/players/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _playersRepository.GetAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        // POST api/players
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            var createdPlayer = await _playersRepository.InsertAsync(player);

            return Created(new Uri($"/api/player/{createdPlayer.Id}", UriKind.Relative), createdPlayer);
        }

        // PUT api/players/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Player player)
        {
            var existingPlayer = await _playersRepository.GetAsync(id);
            if (existingPlayer == null)
                return NotFound();

            player.Id = id;
            existingPlayer = await _playersRepository.UpdateAsync(player);

            return NoContent();
        }

        // DELETE api/players/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deletedPlayer = await _playersRepository.DeleteAsync(id);

            if (!deletedPlayer)
                return NotFound();

            return NoContent();
        }
    }
}
