using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.FeedbackId);

            builder.Property(f => f.SenderId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(f => f.Rate)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(f => f.Content)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(f => f.CreatedDate)
                .IsRequired();

            builder.Property(f => f.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(f => f.Sender)
                .WithMany()
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(f => f.SenderId)
                .HasDatabaseName("IX_Feedback_SenderId");

            builder.HasIndex(f => f.IsDeleted)
                .HasDatabaseName("IX_Feedback_IsDeleted");
        }
    }
}