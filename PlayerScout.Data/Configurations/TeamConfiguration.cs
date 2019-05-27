using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerScout.Data.Model;
using System;

namespace PlayerScout.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();

            builder.Property(t => t.DateCreated).IsRequired();
            builder.Property(t => t.DateCreated).HasDefaultValueSql("GetDate()");

            builder.HasOne<Country>(t => t.Country)
                .WithMany(c => c.Teams)
                .HasForeignKey(a => a.CountryId)
                .IsRequired();
        }
    }
}
