using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdVirtualObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ef662b8-d887-4320-9e35-df2e703f5f2f", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "1ec15fc3-bdc3-44c4-8772-c5d665f8de6c", null, "Admin", "ADMIN" },
                    { "3497adcf-edaa-4e0c-9ef7-218966c12172", null, "Doctor", "DOCTOR" },
                    { "52376ba3-d735-44d3-baad-4ecc7955660d", null, "SuperAdmin", "SUPERADMIN" },
                    { "b38726e2-d8c3-483a-9593-b255b5d6372b", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "c7a13146-994c-4ad8-9df5-d992f2b171c4", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "d289d787-a121-498b-b484-8355f49b8d2e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef662b8-d887-4320-9e35-df2e703f5f2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ec15fc3-bdc3-44c4-8772-c5d665f8de6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3497adcf-edaa-4e0c-9ef7-218966c12172");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52376ba3-d735-44d3-baad-4ecc7955660d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b38726e2-d8c3-483a-9593-b255b5d6372b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7a13146-994c-4ad8-9df5-d992f2b171c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d289d787-a121-498b-b484-8355f49b8d2e");

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
    }
}
