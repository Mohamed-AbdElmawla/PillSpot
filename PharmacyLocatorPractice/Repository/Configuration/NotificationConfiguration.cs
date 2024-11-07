using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.NotificationId);

            builder.Property(n => n.IsNotified)
                .IsRequired();

            builder.Property(n => n.CreatedAt)
                .IsRequired();

            builder.Property(n => n.NotifiedAt)
                .IsRequired();

            builder.Property(n => n.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            builder.HasOne(n => n.PharmacyMedicine)
             .WithMany()
             .HasForeignKey("PharmacyMedicinePharmacyId", "PharmacyMedicineMedicineId") 
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
