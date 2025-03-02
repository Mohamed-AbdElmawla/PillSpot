using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.PermissionId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.HasIndex(p => p.Name)
                .HasDatabaseName("IX_Permission_Name")
                .IsUnique();
        }
    }
}