using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPharmacyProductMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "288e5a5f-9c42-4cca-8621-5e4915d8018f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37649a5e-27a9-4136-9371-7cc045ed1f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5887ffbb-44d4-45bb-a52e-459eb39709d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d1c4b89-3d85-4931-aa3f-7ca2e4cc54fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19d4518-7480-46ba-a872-106b11d12350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e3bf27-bcd1-4956-968a-6a06fb54a04e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b98c7c-cf55-415d-a049-a336b7c27a61");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacy_ProductId_PharmacyId",
                table: "ProductPharmacies",
                newName: "IX_PharmacyProduct_ProductId_PharmacyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0361bfe7-495f-445f-9ff1-12025f502d50", null, "User", "USER" },
                    { "37f05b58-2b1c-49cb-8f87-be5a49d83788", null, "Admin", "ADMIN" },
                    { "54d3d422-cb65-4d91-b198-d29d46f2ba45", null, "Doctor", "DOCTOR" },
                    { "6a29d352-276b-4964-bed8-203bce0482cd", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "8e479ec8-9c2b-44ce-9e4d-ff98b2242205", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "a7a64919-c0ee-4eea-a74b-9813135dc009", null, "SuperAdmin", "SUPERADMIN" },
                    { "f3e76879-d2d1-4aec-b0b7-838c86e91c8e", null, "PharmacyManager", "PHARMACYMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0361bfe7-495f-445f-9ff1-12025f502d50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f05b58-2b1c-49cb-8f87-be5a49d83788");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54d3d422-cb65-4d91-b198-d29d46f2ba45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a29d352-276b-4964-bed8-203bce0482cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e479ec8-9c2b-44ce-9e4d-ff98b2242205");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7a64919-c0ee-4eea-a74b-9813135dc009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3e76879-d2d1-4aec-b0b7-838c86e91c8e");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyProduct_ProductId_PharmacyId",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacy_ProductId_PharmacyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "288e5a5f-9c42-4cca-8621-5e4915d8018f", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "37649a5e-27a9-4136-9371-7cc045ed1f15", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "5887ffbb-44d4-45bb-a52e-459eb39709d4", null, "SuperAdmin", "SUPERADMIN" },
                    { "8d1c4b89-3d85-4931-aa3f-7ca2e4cc54fa", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "f19d4518-7480-46ba-a872-106b11d12350", null, "User", "USER" },
                    { "f1e3bf27-bcd1-4956-968a-6a06fb54a04e", null, "Admin", "ADMIN" },
                    { "f9b98c7c-cf55-415d-a049-a336b7c27a61", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
