using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class GovernementeConfiguration : IEntityTypeConfiguration<Government>
    {
        public void Configure(EntityTypeBuilder<Government> builder)
        {
            builder
                .HasOne(g => g.Location)
                .WithMany(l => l.Governments)
                .HasForeignKey(g => g.LocationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
