using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.CityId);

            builder.Property(c => c.City_Name_AR)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.City_Name_EN)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
