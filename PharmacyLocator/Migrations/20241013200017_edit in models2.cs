using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class editinmodels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d33f2b5-b3c4-4949-b089-d50eab856006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d231d02-584d-4031-86e6-032886282679");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6bd9113-6d05-4919-b320-fd7874655a28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e87753fc-4e0a-4186-8862-669847a2f4de");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0184feee-78d5-4d5b-9c78-164b354e13a9", null, "Pharmacy", "PHARMACY" },
                    { "203e7dff-dcb7-4d3a-94fc-6dd254758053", null, "Admin", "ADMIN" },
                    { "6b80d661-9ac0-49e6-9829-b29e33fa485b", null, "User", "USER" },
                    { "9364ff2f-3828-4c00-9df8-0a5247b0f2bd", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0184feee-78d5-4d5b-9c78-164b354e13a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "203e7dff-dcb7-4d3a-94fc-6dd254758053");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b80d661-9ac0-49e6-9829-b29e33fa485b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9364ff2f-3828-4c00-9df8-0a5247b0f2bd");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d33f2b5-b3c4-4949-b089-d50eab856006", null, "User", "USER" },
                    { "9d231d02-584d-4031-86e6-032886282679", null, "Admin", "ADMIN" },
                    { "c6bd9113-6d05-4919-b320-fd7874655a28", null, "Pharmacy", "PHARMACY" },
                    { "e87753fc-4e0a-4186-8862-669847a2f4de", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
