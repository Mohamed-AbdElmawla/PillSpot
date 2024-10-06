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
    internal class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
             builder.HasData(
                new Medicine
                {
                    Id = 1, 
                    Name = "Aspirin",
                    Description = "Pain reliever and anti-inflammatory",
                    Brand = "Bayer",
                    Dosage = "500 mg"
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Ibuprofen",
                    Description = "Nonsteroidal anti-inflammatory drug (NSAID)",
                    Brand = "Advil",
                    Dosage = "200 mg"
                },
                new Medicine
                {
                    Id = 3,
                    Name = "Paracetamol",
                    Description = "Pain reliever and fever reducer",
                    Brand = "Tylenol",
                    Dosage = "500 mg"
                },
                new Medicine
                {
                    Id = 4,
                    Name = "Amoxicillin",
                    Description = "Antibiotic used to treat bacterial infections",
                    Brand = "Amoxil",
                    Dosage = "250 mg"
                },
                new Medicine
                {
                    Id = 5,
                    Name = "Cetirizine",
                    Description = "Antihistamine used for allergy relief",
                    Brand = "Zyrtec",
                    Dosage = "10 mg"
                }
            );
        }
    }
}
