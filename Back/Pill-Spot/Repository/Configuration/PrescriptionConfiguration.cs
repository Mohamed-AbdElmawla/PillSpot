using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.PrescriptionId);

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.IssueDate)
                .IsRequired();

            builder.Property(p => p.ExpiryDate)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.HasMany(p => p.PrescriptionProducts)
                .WithOne(pp => pp.Prescription)
                .HasForeignKey(pp => pp.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
