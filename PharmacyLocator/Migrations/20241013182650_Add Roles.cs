using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "980dbafd-1b9a-4517-990c-283ef3923aa8", null, "Pharmacy", "PHARMACY" },
                    { "ea26d026-f90d-4fd8-8361-3436ed640113", null, "User", "USER" },
                    { "eb8431e2-9746-4c16-ad77-40ea6e6b13de", null, "Admin", "ADMIN" },
                    { "ffb48c79-b9a7-45ff-aa11-dd3b12e490e2", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980dbafd-1b9a-4517-990c-283ef3923aa8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea26d026-f90d-4fd8-8361-3436ed640113");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8431e2-9746-4c16-ad77-40ea6e6b13de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb48c79-b9a7-45ff-aa11-dd3b12e490e2");
        }
    }
}
