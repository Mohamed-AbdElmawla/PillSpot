using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options) { }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PharmacyMedicine> PharmacyMedicines { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Pharmacy and Medicine
            modelBuilder.Entity<PharmacyMedicine>()
                .HasOne(pm => pm.Pharmacy)
                .WithMany(p => p.PharmacyMedicines)
                .HasForeignKey(pm => pm.PharmacyId);

            modelBuilder.Entity<PharmacyMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.PharmacyMedicines)
                .HasForeignKey(pm => pm.MedicineId);
            modelBuilder.ApplyConfiguration(new PharmacyConfiguration());
            modelBuilder.ApplyConfiguration(new PharmacyMedicineConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineConfiguration());
        }
    }
}
