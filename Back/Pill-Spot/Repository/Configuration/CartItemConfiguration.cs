using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.CartItemId);

            builder.Property(ci => ci.PriceAtAddition)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.AddedAt)
                .IsRequired();

            builder.Property(ci => ci.RejectionReason)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.Property(ci => ci.RowVersion)
                .IsRowVersion();

            builder.Property(ci => ci.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.RespondedByUser)
                .WithMany()
                .HasForeignKey(ci => ci.RespondedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ci => ci.PharmacyProduct)
                .WithMany()
                .HasForeignKey(ci => new { ci.PharmacyId, ci.ProductId })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ci => ci.CartId)
                .HasDatabaseName("IX_CartItem_CartId");
        }
    }
}
