using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c6ffb5f-6391-4d24-ab02-4407cd4b6c34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be0c66e-12d2-4d85-b0f9-5014d4bd3ab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e2fd180-bcc0-4804-b2a5-f242df59ed20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b89c27-aa7a-4e97-b3b1-b5e68156df17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a10c82fe-2a8d-442a-a676-72ae0a8e9e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2202abe-b51f-4e25-bde6-fb4d7d08b767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f91738-dd11-40cd-9109-89369ce15f33");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6c6ffb5f-6391-4d24-ab02-4407cd4b6c34", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "8be0c66e-12d2-4d85-b0f9-5014d4bd3ab1", null, "User", "USER" },
                    { "8e2fd180-bcc0-4804-b2a5-f242df59ed20", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "96b89c27-aa7a-4e97-b3b1-b5e68156df17", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "a10c82fe-2a8d-442a-a676-72ae0a8e9e00", null, "SuperAdmin", "SUPERADMIN" },
                    { "c2202abe-b51f-4e25-bde6-fb4d7d08b767", null, "Admin", "ADMIN" },
                    { "d2f91738-dd11-40cd-9109-89369ce15f33", null, "Doctor", "DOCTOR" }
                });
        }
    }
}
