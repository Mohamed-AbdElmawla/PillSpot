using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderID);

            builder.Property(o => o.UserID)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(o => o.LocationID)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CreatedDate)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.PaymentMethod)
                .IsRequired();

            builder.Property(o => o.IsSuccessful)
                .IsRequired();

            builder.Property(o => o.Currency)
                .IsRequired();

            builder.Property(o => o.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Location)
                .WithMany()
                .HasForeignKey(o => o.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.UserID)
                .HasDatabaseName("IX_Order_UserID");

            builder.HasIndex(o => o.IsDeleted)
                .HasDatabaseName("IX_Order_IsDeleted");
        }
    }
}