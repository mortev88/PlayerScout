using Microsoft.EntityFrameworkCore;
using PlayerScout.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerScout.Data.Repositories
{
    public class TeamsRepository : IGenericRepository<Team>
    {
        private readonly PlayerScoutDbContext _playerScoutDbContext;

        public TeamsRepository(PlayerScoutDbContext playerScoutDbContext)
        {
            _playerScoutDbContext = playerScoutDbContext;
        }

        public async Task<IEnumerable<Team>> AllAsync()
        {
            var teams = await _playerScoutDbContext.Teams
               .ToListAsync();

            return teams;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var team = await _playerScoutDbContext.Teams
           .Where(x => x.Id == id)
           .SingleOrDefaultAsync();

            if (team == null)
                return false;

            _playerScoutDbContext.Teams.Remove(team);
            await _playerScoutDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Team> GetAsync(Guid id)
        {
            return await _playerScoutDbContext.Teams
               .Where(x => x.Id == id)
               .SingleOrDefaultAsync();
        }

        public async Task<Team> InsertAsync(Team team)
        {
            team.DateCreated = DateTime.Now;
            team.DateModified = DateTime.Now;

            await _playerScoutDbContext.Teams.AddAsync(team);
            await _playerScoutDbContext.SaveChangesAsync(true);

            return team;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            var existingTeam = await _playerScoutDbContext.Teams
               .Where(x => x.Id == team.Id)
               .SingleOrDefaultAsync();

            if (existingTeam == null)
                return null;

            existingTeam.Name = team.Name;
            existingTeam.City = team.City;
            existingTeam.DateModified = DateTime.Now;
            existingTeam.CountryId = team.CountryId;

            await _playerScoutDbContext.SaveChangesAsync(true);

            return existingTeam;
        }
    }
}
