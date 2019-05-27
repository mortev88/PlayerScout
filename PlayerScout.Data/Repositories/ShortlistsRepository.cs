using Microsoft.EntityFrameworkCore;
using PlayerScout.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerScout.Data.Repositories
{
    public class ShortlistsRepository : IGenericRepository<Shortlist>
    {
        private readonly PlayerScoutDbContext _playerScoutDbContext;

        public ShortlistsRepository(PlayerScoutDbContext playerScoutDbContext)
        {
            _playerScoutDbContext = playerScoutDbContext;
        }

        public async Task<IEnumerable<Shortlist>> AllAsync()
        {
            var shortlists = await _playerScoutDbContext.Shortlists
               .ToListAsync();

            return shortlists;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var shortlist = await _playerScoutDbContext.Shortlists
           .Where(x => x.Id == id)
           .SingleOrDefaultAsync();

            if (shortlist == null)
                return false;

            _playerScoutDbContext.Shortlists.Remove(shortlist);
            await _playerScoutDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Shortlist> GetAsync(Guid id)
        {
            return await _playerScoutDbContext.Shortlists
               .Where(x => x.Id == id)
               .SingleOrDefaultAsync();
        }

        public async Task<Shortlist> InsertAsync(Shortlist shortlist)
        {
            await _playerScoutDbContext.Shortlists.AddAsync(shortlist);
            await _playerScoutDbContext.SaveChangesAsync(true);

            return shortlist;
        }

        public async Task<Shortlist> UpdateAsync(Shortlist shortlist)
        {
            var existingShortlist = await _playerScoutDbContext.Shortlists
               .Where(x => x.Id == shortlist.Id)
               .SingleOrDefaultAsync();

            if (existingShortlist == null)
                return null;

            existingShortlist.Name = shortlist.Name;
            existingShortlist.Description = shortlist.Description;

            await _playerScoutDbContext.SaveChangesAsync(true);

            return existingShortlist;
        }
    }
}
