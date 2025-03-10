using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePharmacyProductEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e1b356-c2f8-47d1-a888-97f58729897f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48241f7b-efe7-45f3-a35f-21c1ddca189b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627711d4-a573-4b54-8d6d-69a1ff4359f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76103d57-3ec5-4d7d-ab97-277438d7a95b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0348f66-8d99-4679-8a7b-53537ed4073f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de31a300-294a-4920-a4d0-896b9985bbfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4046b0-67a8-4114-9332-e96d4360a24b");

            migrationBuilder.AlterColumn<Guid>(
                name: "BatchId",
                table: "ProductPharmacies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12671984-9f39-495b-b7d4-820540b0c7cd", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "4a143bb1-fae1-47a6-8682-63e2f843b695", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "8c265e3c-1d2c-4399-a6e5-eeb69e2566ef", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "b8a920c7-c86d-4c9d-98bb-b5beec8d33f1", null, "Admin", "ADMIN" },
                    { "dc22b28d-c6b3-495b-bc42-e68e1276d3e0", null, "User", "USER" },
                    { "e71f7820-bd85-43e6-a268-22c45e57f882", null, "Doctor", "DOCTOR" },
                    { "f028b248-303f-4935-9535-5f5d472cb406", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12671984-9f39-495b-b7d4-820540b0c7cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a143bb1-fae1-47a6-8682-63e2f843b695");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c265e3c-1d2c-4399-a6e5-eeb69e2566ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8a920c7-c86d-4c9d-98bb-b5beec8d33f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc22b28d-c6b3-495b-bc42-e68e1276d3e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e71f7820-bd85-43e6-a268-22c45e57f882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f028b248-303f-4935-9535-5f5d472cb406");

            migrationBuilder.AlterColumn<Guid>(
                name: "BatchId",
                table: "ProductPharmacies",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46e1b356-c2f8-47d1-a888-97f58729897f", null, "Admin", "ADMIN" },
                    { "48241f7b-efe7-45f3-a35f-21c1ddca189b", null, "Doctor", "DOCTOR" },
                    { "627711d4-a573-4b54-8d6d-69a1ff4359f7", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "76103d57-3ec5-4d7d-ab97-277438d7a95b", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "c0348f66-8d99-4679-8a7b-53537ed4073f", null, "SuperAdmin", "SUPERADMIN" },
                    { "de31a300-294a-4920-a4d0-896b9985bbfa", null, "User", "USER" },
                    { "ec4046b0-67a8-4114-9332-e96d4360a24b", null, "PharmacyManager", "PHARMACYMANAGER" }
                });
        }
    }
}
