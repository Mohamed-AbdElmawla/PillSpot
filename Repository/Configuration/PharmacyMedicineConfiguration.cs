using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class PharmacyMedicineConfiguration : IEntityTypeConfiguration<PharmacyMedicine>
    {
        public void Configure(EntityTypeBuilder<PharmacyMedicine> builder)
        {
            builder.HasData(
                new PharmacyMedicine
                {
                    Id = 1,
                    PharmacyId = 1, // Link to the Pharmacy with Id = 1
                    MedicineId = 1, // Link to the Medicine with Id = 1
                    StockQuantity = 50,
                    Price = 4.99m,
                    LastUpdated = DateTime.UtcNow
                },
                new PharmacyMedicine
                {
                    Id = 2,
                    PharmacyId = 1, // Link to the Pharmacy with Id = 1
                    MedicineId = 2, // Link to the Medicine with Id = 2
                    StockQuantity = 30,
                    Price = 5.49m,
                    LastUpdated = DateTime.UtcNow
                },
                new PharmacyMedicine
                {
                    Id = 3,
                    PharmacyId = 2, // Link to the Pharmacy with Id = 2
                    MedicineId = 1, // Link to the Medicine with Id = 1
                    StockQuantity = 20,
                    Price = 4.99m,
                    LastUpdated = DateTime.UtcNow
                }
            );
        }

    }
}
