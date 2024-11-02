using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Location)
                .WithMany(l => l.Orders)
                .HasForeignKey(o => o.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
