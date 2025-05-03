using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;
using NetTopologySuite.Geometries;

namespace Repository.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Entities.Models.Location>
    {
        public void Configure(EntityTypeBuilder<Entities.Models.Location> builder)
        {
            builder.HasKey(l => l.LocationId);

            // Removing this line as Geography is NotMapped
            // builder.Property(l => l.Geography)
            //     .HasColumnType("POINT");

            builder.Ignore(l => l.Geography); // Correctly ignoring in mapping

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