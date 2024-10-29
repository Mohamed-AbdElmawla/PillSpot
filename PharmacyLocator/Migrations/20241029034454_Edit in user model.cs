using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class Editinusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2519e081-a3c0-4222-8ce8-96f40a0c3225", null, "User", "USER" },
                    { "3798348a-188e-4fe6-8208-293e39e50763", null, "Admin", "ADMIN" },
                    { "55329e53-4533-43fb-a5eb-7097c22c131b", null, "SuperAdmin", "SUPERADMIN" },
                    { "70276ea3-af95-474a-8966-17afa8173e08", null, "Pharmacy", "PHARMACY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2519e081-a3c0-4222-8ce8-96f40a0c3225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3798348a-188e-4fe6-8208-293e39e50763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55329e53-4533-43fb-a5eb-7097c22c131b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70276ea3-af95-474a-8966-17afa8173e08");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
