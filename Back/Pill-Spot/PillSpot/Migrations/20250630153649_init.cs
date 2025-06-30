using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeeRoles_Pharmacies_PharmacyId",
                table: "PharmacyEmployeeRoles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "PharmacyEmployees");

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "PharmacyEmployeeRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "PharmacyEmployeeRequests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "cefc6a0b-c85d-45bc-8382-9db61e822c33", new DateTime(2025, 6, 30, 15, 36, 43, 709, DateTimeKind.Utc).AddTicks(3424), "AQAAAAIAAYagAAAAECVAbwEll8wll4xNwiV62cBPnE7Yx90yoLSnGW062lRq2nTdQ+6r5eVKJHA0aLHSDg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeeRoles_Pharmacies_PharmacyId",
                table: "PharmacyEmployeeRoles",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeeRoles_Pharmacies_PharmacyId",
                table: "PharmacyEmployeeRoles");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "PharmacyEmployeeRequests");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "PharmacyEmployeeRequests");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "PharmacyEmployees",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d7475de9-2a5a-4f82-bad9-f058a4676698", new DateTime(2025, 6, 30, 0, 0, 12, 163, DateTimeKind.Utc).AddTicks(7827), "AQAAAAIAAYagAAAAEM4B7Ki5OG0LzkdawA3iN+Dsg1qzvC/FCFPEYzcNivya/2LhuT+mtKM0hXZzzUV08A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeeRoles_Pharmacies_PharmacyId",
                table: "PharmacyEmployeeRoles",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
