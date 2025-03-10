using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePharmacyProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14248385-8460-4b25-89bc-e183e4558e3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5973ed89-816c-4f12-a23c-6dc2190599ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ae8d6c7-31e8-4342-93f4-72db2b96b56d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940d4388-d0f6-46ac-9cd2-8ddeb62edf27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b696ae24-707e-4aa7-a65a-43dd5126b0f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda11c62-ea73-4f16-b6b7-8c8fd2df57f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7673556-41ed-4a3f-b444-4d03df7fa6d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46e1b356-c2f8-47d1-a888-97f58729897f", null, "Admin", "ADMIN" },
                    { "48241f7b-efe7-45f3-a35f-21c1ddca189b", null, "Doctor", "DOCTOR" },
                    { "627711d4-a573-4b54-8d6d-69a1ff4359f7", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "76103d57-3ec5-4d7d-ab97-277438d7a95b", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "c0348f66-8d99-4679-8a7b-53537ed4073f", null, "SuperAdmin", "SUPERADMIN" },
                    { "de31a300-294a-4920-a4d0-896b9985bbfa", null, "User", "USER" },
                    { "ec4046b0-67a8-4114-9332-e96d4360a24b", null, "PharmacyManager", "PHARMACYMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e1b356-c2f8-47d1-a888-97f58729897f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48241f7b-efe7-45f3-a35f-21c1ddca189b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627711d4-a573-4b54-8d6d-69a1ff4359f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76103d57-3ec5-4d7d-ab97-277438d7a95b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0348f66-8d99-4679-8a7b-53537ed4073f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de31a300-294a-4920-a4d0-896b9985bbfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4046b0-67a8-4114-9332-e96d4360a24b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14248385-8460-4b25-89bc-e183e4558e3a", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "5973ed89-816c-4f12-a23c-6dc2190599ab", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "5ae8d6c7-31e8-4342-93f4-72db2b96b56d", null, "SuperAdmin", "SUPERADMIN" },
                    { "940d4388-d0f6-46ac-9cd2-8ddeb62edf27", null, "User", "USER" },
                    { "b696ae24-707e-4aa7-a65a-43dd5126b0f1", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "cda11c62-ea73-4f16-b6b7-8c8fd2df57f0", null, "Doctor", "DOCTOR" },
                    { "d7673556-41ed-4a3f-b444-4d03df7fa6d8", null, "Admin", "ADMIN" }
                });
        }
    }
}
