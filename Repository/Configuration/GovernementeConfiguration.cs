using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class GovernmentConfiguration : IEntityTypeConfiguration<Government>
    {
        public void Configure(EntityTypeBuilder<Government> builder)
        {
            builder.ToTable("Governments");

            builder.HasKey(g => g.GovernmentId);

            builder.Property(g => g.Governmente_Name_AR)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(g => g.Governmente_Name_EN)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(g => g.Location)
                .WithMany(l => l.Governments)
                .HasForeignKey(g => g.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.City)
                .WithMany(c => c.Governments)
                .HasForeignKey(g => g.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
