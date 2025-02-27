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
                keyValue: "137f7541-8fdd-491d-b84b-4cad0f350895");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a54a742-383a-4f12-915b-d4eaf8de2611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86883e97-e9cb-4822-9e49-1bbf8a981867");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c75890-356a-468e-917b-4e78668189dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff1fa50-3280-4476-99e8-7fff511d3a47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e767a4a5-ed13-4aea-b8f8-c4a28410ee3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5256742-b137-41ca-b1b1-1f75f7f97ca9");

            migrationBuilder.DropColumn(
                name: "BarcodeImageURL",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07ddb4a5-de67-4a63-8a9a-0a712f8f9f51", null, "Doctor", "DOCTOR" },
                    { "0ea54857-b986-4d25-a3d4-62edaf6d861e", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "5a3111bd-e4eb-4f3c-9eea-5c2c8b4e21af", null, "User", "USER" },
                    { "62648cf7-8917-4bcd-bad8-3b8fae4c54fe", null, "Admin", "ADMIN" },
                    { "6c5c241d-a0fc-4ec9-8ef8-ea151ef14bb3", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "94f1131e-911f-4be4-81dc-0c5172744408", null, "SuperAdmin", "SUPERADMIN" },
                    { "f9c7486c-2fe1-4f06-9cab-24731be45980", null, "PharmacyManager", "PHARMACYMANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ddb4a5-de67-4a63-8a9a-0a712f8f9f51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ea54857-b986-4d25-a3d4-62edaf6d861e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3111bd-e4eb-4f3c-9eea-5c2c8b4e21af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62648cf7-8917-4bcd-bad8-3b8fae4c54fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5c241d-a0fc-4ec9-8ef8-ea151ef14bb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f1131e-911f-4be4-81dc-0c5172744408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9c7486c-2fe1-4f06-9cab-24731be45980");

            migrationBuilder.AddColumn<string>(
                name: "BarcodeImageURL",
                table: "Products",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "137f7541-8fdd-491d-b84b-4cad0f350895", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "4a54a742-383a-4f12-915b-d4eaf8de2611", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "86883e97-e9cb-4822-9e49-1bbf8a981867", null, "SuperAdmin", "SUPERADMIN" },
                    { "a9c75890-356a-468e-917b-4e78668189dc", null, "Doctor", "DOCTOR" },
                    { "dff1fa50-3280-4476-99e8-7fff511d3a47", null, "User", "USER" },
                    { "e767a4a5-ed13-4aea-b8f8-c4a28410ee3a", null, "Admin", "ADMIN" },
                    { "f5256742-b137-41ca-b1b1-1f75f7f97ca9", null, "PharmacyOwner", "PHARMACYOWNER" }
                });
        }
    }
}
