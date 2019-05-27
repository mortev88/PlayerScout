using Microsoft.EntityFrameworkCore;
using PlayerScout.Data.Configurations;
using PlayerScout.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PlayerScout.Data
{
    public class PlayerScoutDbContext : DbContext
    {
        private const string ResourcesPath = "PlayerScout.Data.Resources";
        private delegate void LoadResourceCallback(string line);

        public PlayerScoutDbContext(DbContextOptions<PlayerScoutDbContext> options)
          : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Shortlist> Shortlists { get; set; }
        public DbSet<ShortlistItem> ShortlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ShortlistItemConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityConfiguration());
            modelBuilder.ApplyConfiguration(new ShortlistConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            LoadCountries(modelBuilder);
            LoadNationalities(modelBuilder);
            LoadTeams(modelBuilder);
        }

        private void LoadResource(string resourcePath, string name, LoadResourceCallback callback)
        {
            string resource = string.Format("{0}.{1}.txt", resourcePath, name);
            string line = null;
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                if (s == null)
                    return;

                using (StreamReader reader = new StreamReader(s))
                {
                    while ((line = reader.ReadLine()) != null)
                        callback(line);
                }
            }
        }

        private void LoadCountries(ModelBuilder builder)
        {
            LoadResource(ResourcesPath, "countries", delegate (string line) {
                if (string.IsNullOrWhiteSpace(line))
                    return;

                var fields = line.Split(';');

                Country country = new Country();
                country.Id = Guid.Parse(fields[0].Trim());
                country.Name = fields[1].Trim();

                builder.Entity<Country>().HasData(country);
            });
        }

        private void LoadNationalities(ModelBuilder builder)
        {
            LoadResource(ResourcesPath, "nationalities", delegate (string line) {
                if (string.IsNullOrWhiteSpace(line))
                    return;

                var fields = line.Split(';');

                Nationality nationality = new Nationality();
                nationality.Id = Guid.Parse(fields[0].Trim());
                nationality.Name = fields[1].Trim();

                builder.Entity<Nationality>().HasData(nationality);
            });
        }

        private void LoadTeams(ModelBuilder builder)
        {
            var timestamp = DateTime.Now;

            LoadResource(ResourcesPath, "teams", delegate (string line) {
                if (string.IsNullOrWhiteSpace(line))
                    return;

                var fields = line.Split(';');

                Team team = new Team();
                team.Id = Guid.Parse(fields[0].Trim());
                team.Name = fields[1].Trim();
                team.City = fields[2].Trim();
                team.CountryId = Guid.Parse(fields[3].Trim());
                team.DateCreated = timestamp;
                team.DateModified = timestamp;

                builder.Entity<Team>().HasData(team);
            });
        }
    }
}
