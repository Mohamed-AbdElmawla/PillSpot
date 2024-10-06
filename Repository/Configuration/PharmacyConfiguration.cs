using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.HasData(
                new Pharmacy
                {
                    Id=1,
                    Name = "El Ezaby",
                    Address = "195 Haram Street, El Haram, Giza",
                    City = "El Haram",
                    ContactNumber = "19600",
                    IsOpen24Hours = true,
                    Latitude = 12.203m,
                    Longitude = 2.3m,
                    OpeningHours = "24",
                    State = "Giza",
                    ZipCode = "2132"
                },
                new Pharmacy
                {
                    Id=2,
                    Name = "Ezz Eldin",
                    Address = "Shop No. 7 Ground Floor, Triangle Area, Gamal AbdeNasser Square, Diplomats Area, Arabella Mall, 5thSettlement",
                    City = "FIFTH SETTLEMENT",
                    ContactNumber = "19600",
                    IsOpen24Hours = true,
                    Latitude = 22.203m,
                    Longitude = 3.3m,
                    OpeningHours = "24",
                    State = "Cairo",
                    ZipCode = "2132"
                }
            );
        }
    }
}
