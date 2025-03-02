using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(o => o.LocationId)
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
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Location)
                .WithMany()
                .HasForeignKey(o => o.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(o => o.UserId)
                .HasDatabaseName("IX_Order_UserId");

            builder.HasIndex(o => o.IsDeleted)
                .HasDatabaseName("IX_Order_IsDeleted");
        }
    }
}