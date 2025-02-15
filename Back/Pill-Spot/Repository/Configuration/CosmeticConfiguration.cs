using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class CosmeticConfiguration : IEntityTypeConfiguration<Cosmetic>
    {
        public void Configure(EntityTypeBuilder<Cosmetic> builder)
        {
            builder.HasBaseType<Product>();

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(c => c.SkinType)
                .IsRequired();

            builder.Property(c => c.UsageInstructions)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(c => c.Volume)
                .IsRequired();

            builder.HasIndex(c => c.Brand)
                .HasDatabaseName("IX_Cosmetic_Brand");
        }
    }
}