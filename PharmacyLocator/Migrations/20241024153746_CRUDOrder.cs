using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class CRUDOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c15af0-2c81-4a39-9e59-74f12c9dc1db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27b57876-2d18-42c1-b865-38e819c5b4c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88f54e08-20ed-4524-956b-5b05b60dbe55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78dd4d7-8fcf-4e70-83dd-25aa47a9140d");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8aa09d5b-c6c1-46d6-8764-dcdba3c7643f", null, "Pharmacy", "PHARMACY" },
                    { "a0fa4158-7424-454d-b78c-df18f7ed2274", null, "User", "USER" },
                    { "acbedad5-eb9b-440c-9ab4-87fb38299dc6", null, "Admin", "ADMIN" },
                    { "ae970e57-5197-41ca-a203-1a82c188602e", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aa09d5b-c6c1-46d6-8764-dcdba3c7643f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0fa4158-7424-454d-b78c-df18f7ed2274");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acbedad5-eb9b-440c-9ab4-87fb38299dc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae970e57-5197-41ca-a203-1a82c188602e");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Medicines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09c15af0-2c81-4a39-9e59-74f12c9dc1db", null, "Pharmacy", "PHARMACY" },
                    { "27b57876-2d18-42c1-b865-38e819c5b4c2", null, "User", "USER" },
                    { "88f54e08-20ed-4524-956b-5b05b60dbe55", null, "Admin", "ADMIN" },
                    { "b78dd4d7-8fcf-4e70-83dd-25aa47a9140d", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
