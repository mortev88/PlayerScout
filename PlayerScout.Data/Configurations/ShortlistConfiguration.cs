using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerScout.Data.Model;

namespace PlayerScout.Data.Configurations
{
    public class ShortlistConfiguration : IEntityTypeConfiguration<Shortlist>
    {
        public void Configure(EntityTypeBuilder<Shortlist> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired();
        }
    }
}
