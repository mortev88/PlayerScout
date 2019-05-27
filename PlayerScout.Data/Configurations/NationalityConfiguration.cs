using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerScout.Data.Model;

namespace PlayerScout.Data.Configurations
{
    public class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired();
        }
    }
}
