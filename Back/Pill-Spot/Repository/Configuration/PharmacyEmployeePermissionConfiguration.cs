using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyEmployeePermissionConfiguration : IEntityTypeConfiguration<PharmacyEmployeePermission>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployeePermission> builder)
        {
            builder.HasKey(pe => new { pe.EmployeeId, pe.PermissionId });

            builder.HasOne(pe => pe.PharmacyEmployee)
                .WithMany(pe => pe.PharmacyEmployeePermissions)
                .HasForeignKey(pe => pe.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pe => pe.Permission)
                .WithMany(p => p.PharmacyEmployeePermissions)
                .HasForeignKey(pe => pe.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pe => new { pe.EmployeeId, pe.PermissionId })
                .HasDatabaseName("IX_PharmacyEmployeePermission_EmployeeID_PermissionID");
        }
    }
}
