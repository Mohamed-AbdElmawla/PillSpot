using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBatchFromPharmacyProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId1",
                table: "ProductPharmacies");

            migrationBuilder.DropIndex(
                name: "IX_ProductPharmacies_BatchId1",
                table: "ProductPharmacies");

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

            migrationBuilder.DropColumn(
                name: "BatchId1",
                table: "ProductPharmacies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1719d7a1-e45d-434b-adb6-1048ac583af1", null, "Doctor", "DOCTOR" },
                    { "449ed6c3-cde2-487a-a390-ca42a675ec10", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "50e77029-0fce-43a6-b498-2eb877a69b47", null, "Admin", "ADMIN" },
                    { "5114b881-e0ea-4ebc-b689-2de934014a27", null, "SuperAdmin", "SUPERADMIN" },
                    { "89f5856d-c566-4d9e-aefa-b85f02731f64", null, "User", "USER" },
                    { "cbfdb6dd-15b9-4b0d-a732-05c6a0cb547f", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "e6b081e5-c99d-40f8-9a8d-19a2792322ee", null, "PharmacyManager", "PHARMACYMANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "BatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1719d7a1-e45d-434b-adb6-1048ac583af1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "449ed6c3-cde2-487a-a390-ca42a675ec10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e77029-0fce-43a6-b498-2eb877a69b47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5114b881-e0ea-4ebc-b689-2de934014a27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89f5856d-c566-4d9e-aefa-b85f02731f64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbfdb6dd-15b9-4b0d-a732-05c6a0cb547f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6b081e5-c99d-40f8-9a8d-19a2792322ee");

            migrationBuilder.AddColumn<Guid>(
                name: "BatchId1",
                table: "ProductPharmacies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductPharmacies_BatchId1",
                table: "ProductPharmacies",
                column: "BatchId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId1",
                table: "ProductPharmacies",
                column: "BatchId1",
                principalTable: "Batches",
                principalColumn: "BatchId");
        }
    }
}
