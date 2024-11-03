using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class pharmacylogonull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e1e085-6458-40e6-a54c-19020732b4c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5ce77a-76f8-417c-8b90-96bcff3211d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732e5901-8798-4c75-bd3d-22caa46a4d1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e6ed3e-6a5d-4e5f-b336-cb570b860e6b");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "063c9d86-13ac-4e6e-aca7-b46a43cf6957", null, "SuperAdmin", "SUPERADMIN" },
                    { "de4444f6-539d-4dee-b8ed-5f6d17a77fee", null, "Pharmacy", "PHARMACY" },
                    { "e1a64d86-b781-4691-a22b-c0b3249676f4", null, "User", "USER" },
                    { "fb82713d-84d0-4d00-8350-da0281593f5f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "063c9d86-13ac-4e6e-aca7-b46a43cf6957");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de4444f6-539d-4dee-b8ed-5f6d17a77fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a64d86-b781-4691-a22b-c0b3249676f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb82713d-84d0-4d00-8350-da0281593f5f");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Pharmacies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e1e085-6458-40e6-a54c-19020732b4c9", null, "SuperAdmin", "SUPERADMIN" },
                    { "1b5ce77a-76f8-417c-8b90-96bcff3211d0", null, "User", "USER" },
                    { "732e5901-8798-4c75-bd3d-22caa46a4d1d", null, "Pharmacy", "PHARMACY" },
                    { "d0e6ed3e-6a5d-4e5f-b336-cb570b860e6b", null, "Admin", "ADMIN" }
                });
        }
    }
}
