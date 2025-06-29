using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PharmacyProductNotificationPreferenceConfiguration : IEntityTypeConfiguration<PharmacyProductNotificationPreference>
    {
        public void Configure(EntityTypeBuilder<PharmacyProductNotificationPreference> builder)
        {
            builder.ToTable("PharmacyProductNotificationPreferences");

            builder.HasKey(p => p.PreferenceId);

            builder.Property(p => p.PreferenceId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.PharmacyId)
                .IsRequired(false);

            builder.Property(p => p.IsEnabled)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(p => p.NotificationTypes)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                .HasColumnType("longtext");

            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("(UTC_TIMESTAMP())");

            builder.Property(p => p.LastNotifiedAt)
                .IsRequired(false);

            // Relationships
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Pharmacy)
                .WithMany()
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(p => new { p.UserId, p.ProductId, p.PharmacyId })
                .IsUnique()
                .HasDatabaseName("IX_PharmacyProductNotificationPreference_User_Product_Pharmacy");

            builder.HasIndex(p => p.UserId)
                .HasDatabaseName("IX_PharmacyProductNotificationPreference_UserId");

            builder.HasIndex(p => p.ProductId)
                .HasDatabaseName("IX_PharmacyProductNotificationPreference_ProductId");

            builder.HasIndex(p => p.PharmacyId)
                .HasDatabaseName("IX_PharmacyProductNotificationPreference_PharmacyId");

            builder.HasIndex(p => p.IsEnabled)
                .HasDatabaseName("IX_PharmacyProductNotificationPreference_IsEnabled");
        }
    }
} 