using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserInLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_LocationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26a6c2e3-d85a-4556-acd4-6b50a33fa1fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426091c6-a09f-4cbe-ac28-593d9e3793f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc2a43f-1044-437e-a0da-13108eda5502");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e88f2bf1-c239-4c6d-aa37-152037a543bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "604e5e07-660f-41fa-91c1-25900468c35e", null, "User", "USER" },
                    { "85a54b5d-b47a-4747-b127-457f7908a9ee", null, "Pharmacy", "PHARMACY" },
                    { "898e9291-361b-4d4f-9099-f7424b5e2a6b", null, "Admin", "ADMIN" },
                    { "9bff9441-e676-4d1d-9f50-e0c90d158882", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_LocationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "604e5e07-660f-41fa-91c1-25900468c35e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85a54b5d-b47a-4747-b127-457f7908a9ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "898e9291-361b-4d4f-9099-f7424b5e2a6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bff9441-e676-4d1d-9f50-e0c90d158882");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26a6c2e3-d85a-4556-acd4-6b50a33fa1fc", null, "Admin", "ADMIN" },
                    { "426091c6-a09f-4cbe-ac28-593d9e3793f3", null, "User", "USER" },
                    { "8cc2a43f-1044-437e-a0da-13108eda5502", null, "Pharmacy", "PHARMACY" },
                    { "e88f2bf1-c239-4c6d-aa37-152037a543bf", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");
        }
    }
}
