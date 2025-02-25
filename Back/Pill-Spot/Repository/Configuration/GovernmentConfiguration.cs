using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class GovernmentConfiguration : IEntityTypeConfiguration<Government>
    {
        public void Configure(EntityTypeBuilder<Government> builder)
        {
            builder.HasKey(g => g.GovernmentId);

            builder.Property(g => g.GovernmentName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Property(g => g.CreatedDate)
                .IsRequired();

            builder.Property(g => g.IsDeleted)
                .HasDefaultValue(false);

            builder.HasIndex(g => g.GovernmentName)
                .HasDatabaseName("IX_Government_Name")
                .IsUnique();

            builder.HasIndex(g => g.IsDeleted)
                .HasDatabaseName("IX_Government_IsDeleted");

            builder.HasMany(g => g.Cities)
                .WithOne(c => c.Government)
                .HasForeignKey(c => c.GovernmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}