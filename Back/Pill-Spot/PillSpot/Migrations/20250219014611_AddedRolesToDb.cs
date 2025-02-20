using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3186750a-8d81-43fd-b4dc-42d7a8e3f621", null, "User", "USER" },
                    { "4181afd1-b3bb-4c29-b6ac-a1c105042eb9", null, "Doctor", "DOCTOR" },
                    { "795ec8e9-a946-4394-bfad-5d3fde98149e", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "8140aa22-0894-47da-8b95-39bbc60d4cff", null, "Admin", "ADMIN" },
                    { "9d3c34dc-a522-4aac-ad44-92d36a6f4e4a", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "f0851248-1355-480c-8c80-5c4799713414", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "fb1e5088-23c3-466c-b1ce-1e477413a9c1", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3186750a-8d81-43fd-b4dc-42d7a8e3f621");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4181afd1-b3bb-4c29-b6ac-a1c105042eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "795ec8e9-a946-4394-bfad-5d3fde98149e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8140aa22-0894-47da-8b95-39bbc60d4cff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d3c34dc-a522-4aac-ad44-92d36a6f4e4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0851248-1355-480c-8c80-5c4799713414");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb1e5088-23c3-466c-b1ce-1e477413a9c1");
        }
    }
}
