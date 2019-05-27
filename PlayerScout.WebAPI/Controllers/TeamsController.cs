using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerScout.Data.Model;
using PlayerScout.Data.Repositories;

namespace PlayerScout.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IGenericRepository<Team> _teamsRepository;

        public TeamsController(IGenericRepository<Team> teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        // GET api/teams
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _teamsRepository.AllAsync();
            if (teams == null)
                return NotFound();

            return Ok(teams);
        }

        // GET api/teams/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var team = await _teamsRepository.GetAsync(id);
            if (team == null)
                return NotFound();

            return Ok(team);
        }

        // POST api/teams
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            var createdTeam = await _teamsRepository.InsertAsync(team);

            return Created(new Uri($"/api/team/{createdTeam.Id}", UriKind.Relative), createdTeam);
        }

        // PUT api/teams/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Team team)
        {
            var existingTeam = await _teamsRepository.GetAsync(id);
            if (existingTeam == null)
                return NotFound();

            team.Id = id;
            existingTeam = await _teamsRepository.UpdateAsync(team);

            return NoContent();
        }

        // DELETE api/teams/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deletedTeam = await _teamsRepository.DeleteAsync(id);

            if (!deletedTeam)
                return NotFound();

            return NoContent();
        }
    }
}
