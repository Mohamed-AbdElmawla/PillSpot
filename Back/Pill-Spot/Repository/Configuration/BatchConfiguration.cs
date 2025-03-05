using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasKey(b => b.BatchId);

            builder.Property(b => b.BatchNumber)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(b => b.ManufactureDate)
                .IsRequired();

            builder.Property(b => b.ExpirationDate)
                .IsRequired();

            builder.Property(b => b.CreatedDate)
                .IsRequired();

            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(b => b.RowVersion)
                .IsRowVersion();
            builder.HasIndex(c => c.IsDeleted)
                .HasDatabaseName("IX_Batch_IsDeleted");
            builder.HasIndex(b => b.BatchNumber)
                .HasDatabaseName("IX_Batch_BatchNumber")
                .IsUnique();
        }
    }
}