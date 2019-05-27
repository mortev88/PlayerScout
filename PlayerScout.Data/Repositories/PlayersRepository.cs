using Microsoft.EntityFrameworkCore;
using PlayerScout.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerScout.Data.Repositories
{
    public class PlayersRepository : IGenericRepository<Player>
    {
        private readonly PlayerScoutDbContext _playerScoutDbContext;

        public PlayersRepository(PlayerScoutDbContext playerScoutDbContext)
        {
            _playerScoutDbContext = playerScoutDbContext;
        }

        public async Task<IEnumerable<Player>> AllAsync()
        {
            var players = await _playerScoutDbContext.Players
               .ToListAsync();

            return players;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var player = await _playerScoutDbContext.Players
           .Where(x => x.Id == id)
           .SingleOrDefaultAsync();

            if (player == null)
                return false;

            _playerScoutDbContext.Players.Remove(player);
            await _playerScoutDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await _playerScoutDbContext.Players
               .Where(x => x.Id == id)
               .SingleOrDefaultAsync();
        }

        public async Task<Player> InsertAsync(Player player)
        {
            player.DateCreated = DateTime.Now;
            player.DateModified = DateTime.Now;

            await _playerScoutDbContext.Players.AddAsync(player);
            await _playerScoutDbContext.SaveChangesAsync(true);

            return player;
        }

        public async Task<Player> UpdateAsync(Player player)
        {
            var existingPlayer = await _playerScoutDbContext.Players
               .Where(x => x.Id == player.Id)
               .SingleOrDefaultAsync();

            if (existingPlayer == null)
                return null;

            existingPlayer.DateModified = DateTime.Now;
            existingPlayer.FirstName = player.FirstName;
            existingPlayer.LastName = player.LastName;
            existingPlayer.DateOfBirth = player.DateOfBirth;
            //existingPlayer.TeamId = player.TeamId;
            //existingPlayer.NationalityId = player.NationalityId;
            existingPlayer.Height = player.Height;
            existingPlayer.Weight = player.Weight;
            existingPlayer.Dribbling = player.Dribbling;
            existingPlayer.Heading = player.Heading;
            existingPlayer.Marking = player.Marking;
            existingPlayer.Pace = player.Pace;
            existingPlayer.Passing = player.Passing;
            existingPlayer.Shooting = player.Shooting;
            existingPlayer.Stamina = player.Stamina;
            existingPlayer.Strength = player.Strength;
            existingPlayer.Tackling = player.Tackling;

            await _playerScoutDbContext.SaveChangesAsync(true);

            return existingPlayer;
        }
    }
}
