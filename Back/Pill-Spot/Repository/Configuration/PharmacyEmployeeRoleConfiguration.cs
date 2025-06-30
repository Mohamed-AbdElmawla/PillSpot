using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyEmployeeRoleConfiguration : IEntityTypeConfiguration<PharmacyEmployeeRole>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployeeRole> builder)
        {
            builder.HasKey(per => per.employeeRoleId);

            builder.HasOne(per => per.Employee)
                .WithMany(Pe => Pe.PharmacyEmployeeRoles)
                .HasForeignKey(per => per.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(per => per.Pharmacy)
            //    .WithMany(Pe => Pe.PharmacyEmployeeRoles)
            //    .HasForeignKey(per => per.PharmacyId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(per => per.Role)
                .WithMany()
                .HasForeignKey(per => per.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(per => per.CreatedAt)
                .IsRequired();
        }
    }
}