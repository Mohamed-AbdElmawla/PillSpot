using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class editinmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "SOSNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "SOSNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
