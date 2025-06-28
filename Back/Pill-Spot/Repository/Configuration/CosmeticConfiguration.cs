using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
     public class CosmeticConfiguration : IEntityTypeConfiguration<Cosmetic>
    {
        public void Configure(EntityTypeBuilder<Cosmetic> builder)
        {
            builder.ToTable("Cosmetics");

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(c => c.SkinType)
                .IsRequired();

            builder.Property(c => c.Volume)
                .IsRequired();
        }
    }

}