using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.LocationID);

            builder.Property(l => l.Longitude)
                .IsRequired()
                .HasColumnType("decimal(9,6)");

            builder.Property(l => l.Latitude)
                .IsRequired()
                .HasColumnType("decimal(8,6)");

            builder.Property(l => l.AdditionalInfo)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(l => l.CreatedDate)
                .IsRequired();

            builder.Property(l => l.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(l => l.City)
                .WithMany()
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(l => new { l.Longitude, l.Latitude })
                .HasDatabaseName("IX_Location_Coordinates");

            builder.HasIndex(l => l.IsDeleted)
                .HasDatabaseName("IX_Location_IsDeleted");
        }
    }
}