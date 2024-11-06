using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasMany(l => l.Users)
                .WithOne(u => u.Location)
                .HasForeignKey(u => u.LocationId);

            builder.HasMany(l => l.Cities)
                .WithOne(c => c.Location)
                .HasForeignKey(c => c.CityId);

            builder.HasMany(l => l.Governments)
                .WithOne(g => g.Location)
                .HasForeignKey(g => g.GovernmentId);

            builder.HasMany(l => l.Pharmacies)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
        }
    }
}
