using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.OrderItemID);

            builder.Property(oi => oi.PharmacyBranchID)
                .IsRequired();

            builder.Property(oi => oi.ProductID)
                .IsRequired();

            builder.Property(oi => oi.OrderID)
                .IsRequired();

            builder.Property(oi => oi.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Quantity)
                .IsRequired();

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oi => oi.PharmacyBranch)
                .WithMany()
                .HasForeignKey(oi => oi.PharmacyBranchID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(oi => new { oi.OrderID, oi.ProductID })
                .HasDatabaseName("IX_OrderItem_OrderID_ProductID");
        }
    }
}