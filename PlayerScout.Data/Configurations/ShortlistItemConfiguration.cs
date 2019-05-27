using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerScout.Data.Model;

namespace PlayerScout.Data.Configurations
{
    public class ShortlistItemConfiguration : IEntityTypeConfiguration<ShortlistItem>
    {
        public void Configure(EntityTypeBuilder<ShortlistItem> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.DateCreated).IsRequired();
            builder.Property(s => s.DateCreated).HasDefaultValueSql("GetDate()");

            builder.HasOne<Player>(s => s.Player)
                .WithMany(p => p.ShortlistItems)
                .HasForeignKey(a => a.PlayerId)
                .IsRequired();

            builder.HasOne<Shortlist>(s => s.Shortlist)
                .WithMany(s => s.ShortlistItems)
                .HasForeignKey(a => a.ShortlistId)
                .IsRequired();
        }
    }
}
