using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerScout.Data.Model;

namespace PlayerScout.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.DateCreated).IsRequired();
            builder.Property(a => a.DateCreated).HasDefaultValueSql("GetDate()");
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.DateOfBirth).HasColumnType("Date");

            builder.Property(a => a.Dribbling).IsRequired();
            builder.Property(a => a.Heading).IsRequired();
            builder.Property(a => a.Marking).IsRequired();
            builder.Property(a => a.Pace).IsRequired();
            builder.Property(a => a.Passing).IsRequired();
            builder.Property(a => a.Shooting).IsRequired();
            builder.Property(a => a.Stamina).IsRequired();
            builder.Property(a => a.Strength).IsRequired();
            builder.Property(a => a.Tackling).IsRequired();

            builder.HasOne<Team>(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(a => a.TeamId);

            builder.HasOne<Nationality>(p => p.Nationality)
                .WithMany(n => n.Players)
                .HasForeignKey(a => a.NationalityId);
        }
    }
}
