using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class editinmodels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
