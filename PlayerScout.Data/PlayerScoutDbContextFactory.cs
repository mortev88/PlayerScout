using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PlayerScout.Common;

namespace PlayerScout.Data
{
    public class PlayerScoutDbContextFactory : IDesignTimeDbContextFactory<PlayerScoutDbContext>
    {
        public PlayerScoutDbContext CreateDbContext(string[] args)
        {
            var configuration = CoreConfigurationProvider.BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PlayerScoutDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("PlayerScoutDbContext"), b => b.MigrationsAssembly("PlayerScout.Data"));
            return new PlayerScoutDbContext(builder.Options);
        }
    }
}
