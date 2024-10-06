using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyLocator.Migrations
{
    public partial class SeedPharmacyMedicineData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "Brand", "Description", "Dosage", "Name" },
                values: new object[,]
                {
                    { 1, "Bayer", "Pain reliever and anti-inflammatory", "500 mg", "Aspirin" },
                    { 2, "Advil", "Nonsteroidal anti-inflammatory drug (NSAID)", "200 mg", "Ibuprofen" },
                    { 3, "Tylenol", "Pain reliever and fever reducer", "500 mg", "Paracetamol" },
                    { 4, "Amoxil", "Antibiotic used to treat bacterial infections", "250 mg", "Amoxicillin" },
                    { 5, "Zyrtec", "Antihistamine used for allergy relief", "10 mg", "Cetirizine" }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "PharmacyId", "Address", "City", "ContactNumber", "IsOpen24Hours", "Latitude", "Longitude", "Name", "OpeningHours", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "195 Haram Street, El Haram, Giza", "El Haram", "19600", true, 12.203m, 2.3m, "El Ezaby", "24", "Giza", "2132" },
                    { 2, "Shop No. 7 Ground Floor, Triangle Area, Gamal AbdeNasser Square, Diplomats Area, Arabella Mall, 5thSettlement", "FIFTH SETTLEMENT", "19600", true, 22.203m, 3.3m, "Ezz Eldin", "24", "Cairo", "2132" }
                });

            migrationBuilder.InsertData(
                table: "PharmacyMedicines",
                columns: new[] { "PharmacyMedicineId", "LastUpdated", "MedicineId", "PharmacyId", "Price", "StockQuantity" },
                values: new object[] { 1, new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3504), 1, 1, 4.99m, 50 });

            migrationBuilder.InsertData(
                table: "PharmacyMedicines",
                columns: new[] { "PharmacyMedicineId", "LastUpdated", "MedicineId", "PharmacyId", "Price", "StockQuantity" },
                values: new object[] { 2, new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3507), 2, 1, 5.49m, 30 });

            migrationBuilder.InsertData(
                table: "PharmacyMedicines",
                columns: new[] { "PharmacyMedicineId", "LastUpdated", "MedicineId", "PharmacyId", "Price", "StockQuantity" },
                values: new object[] { 3, new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3508), 1, 2, 4.99m, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 2);
        }
    }
}
