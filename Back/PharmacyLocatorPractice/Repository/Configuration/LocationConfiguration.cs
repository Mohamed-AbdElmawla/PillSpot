using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Repository.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasKey(l => l.LocationId);

            builder.Property(l => l.Longitude)
                .IsRequired();

            builder.Property(l => l.Latitude)
                .IsRequired();

            builder.Property(l => l.AdditionalInfo)
                .HasMaxLength(1000);

            builder.HasMany(l => l.Orders)
                .WithOne(o => o.Location)
                .HasForeignKey(o => o.LocationId);

            builder
           .HasOne(l => l.City)
           .WithMany()
           .HasForeignKey(l => l.CityId)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
