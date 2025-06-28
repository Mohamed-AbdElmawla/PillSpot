using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.CartId);

            builder.Property(c => c.CartType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.IsLocked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.RowVersion)
                .IsRowVersion();

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.DeliveryAddress)
                .WithMany()
                .HasForeignKey(c => c.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Items)
                .WithOne(i => i.Cart)
                .HasForeignKey(i => i.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(c => c.UserId)
                .HasDatabaseName("IX_Cart_UserId");
        }
    }
}
