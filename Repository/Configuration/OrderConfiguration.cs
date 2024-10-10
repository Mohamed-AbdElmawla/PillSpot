using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

            builder
              .HasOne(o => o.Location)
              .WithMany(l => l.Orders)
              .HasForeignKey(o => o.LocationId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
