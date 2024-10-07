using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyLocator.Migrations
{
    public partial class UpdatedMedicineEntitiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 7, 12, 16, 18, 138, DateTimeKind.Utc).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 7, 12, 16, 18, 138, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 7, 12, 16, 18, 138, DateTimeKind.Utc).AddTicks(8599));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "PharmacyMedicines",
                keyColumn: "PharmacyMedicineId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 30, 14, 14, 42, 901, DateTimeKind.Utc).AddTicks(3508));
        }
    }
}
