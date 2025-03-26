using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class PharmacyEmployeeConfiguration : IEntityTypeConfiguration<PharmacyEmployee>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployee> builder)
        {
            builder.HasKey(pe => pe.EmployeeId);

            builder.Property(pe => pe.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .IsUnicode(true);

            builder.Property(pe => pe.PharmacyId)
                .IsRequired();

            builder.Property(pe => pe.Role)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(pe => pe.HireDate)
                .IsRequired();


            builder.Property(pe => pe.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(pe => pe.User)
                .WithMany()
                .HasForeignKey(pe => pe.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pe => pe.Pharmacy)
                .WithMany(p => p.Employees)
                .HasForeignKey(pe => pe.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pe => new { pe.UserId, pe.PharmacyId })
                .HasDatabaseName("IX_PharmacyEmployee_UserId_PharmacyId");

            builder.HasIndex(pe => pe.IsDeleted)
                .HasDatabaseName("IX_PharmacyEmployee_IsDeleted");
        }
    }
}

namespace Repository.Configuration
{
    public class PharmacyEmployeeRoleConfiguration : IEntityTypeConfiguration<PharmacyEmployeeRole>
    {
        public void Configure(EntityTypeBuilder<PharmacyEmployeeRole> builder)
        {
            builder.HasKey(per => per.employeeRoleId);

            builder.HasOne(per => per.employees)
                .WithMany(Pe => Pe.PharmacyEmployeeRoles)
                .HasForeignKey(per => per.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(per => per.pharmacies)
                .WithMany(Pe => Pe.PharmacyEmployeeRoles)
                .HasForeignKey(per => per.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(per => per.Role)
                .WithMany()
                .HasForeignKey(per => per.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(per => per.CreatedAt)
                .IsRequired();
        }
    }
}