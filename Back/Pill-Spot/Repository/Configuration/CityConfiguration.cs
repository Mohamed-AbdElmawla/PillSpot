using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            builder.Property(c => c.CityNameAR)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(c => c.CityNameEN)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.HasIndex(c => new { c.CityNameAR, c.CityNameEN })
                .HasDatabaseName("IX_City_Names")
                .IsUnique();

            builder.HasIndex(c => c.IsDeleted)
                .HasDatabaseName("IX_City_IsDeleted");

            builder.HasOne(c => c.Government)
                .WithMany(g => g.Cities)
                .HasForeignKey(c => c.GovernmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}