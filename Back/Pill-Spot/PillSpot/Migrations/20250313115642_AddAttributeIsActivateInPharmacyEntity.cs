using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddAttributeIsActivateInPharmacyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "270753dc-0d6b-423d-9801-ff9ae8c08cd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e12f69a-7dd3-49df-9233-685e42fd90fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7048cf30-f74d-4a57-8740-3a1ed05a8706");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2e2009-8526-401c-bfac-ddfb4e11504b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b98d936-64e3-44d3-899a-2bf01be8409f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc1927a1-c868-4c2e-9064-883acdca5b86");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pharmacies",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86fcc22b-2ab1-4cab-9573-1e5bf8e5560c", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "97c95338-131f-430f-8bb7-d9800a92f0d4", null, "User", "USER" },
                    { "a56c21a8-13df-4a64-925d-a5bb9b912bef", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "be7872cb-8ae4-4dbe-8ef8-baba022d4f4b", null, "Admin", "ADMIN" },
                    { "c626a80c-5be8-4bc8-97ee-8577a9b1ecbe", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "e51fe752-f4b5-4308-9505-efd4550d7926", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "5ea50b93-4f34-42d8-ad85-85c052b7598e", new DateTime(2025, 3, 13, 11, 56, 36, 54, DateTimeKind.Utc).AddTicks(5508), "AQAAAAIAAYagAAAAECfH+eYdfxJvFSDuDw3lmA9XWc4mSBuVFHf9LOlJ2jEshR4b2mAMR6jwpfPOy8nB8g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86fcc22b-2ab1-4cab-9573-1e5bf8e5560c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c95338-131f-430f-8bb7-d9800a92f0d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a56c21a8-13df-4a64-925d-a5bb9b912bef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be7872cb-8ae4-4dbe-8ef8-baba022d4f4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c626a80c-5be8-4bc8-97ee-8577a9b1ecbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e51fe752-f4b5-4308-9505-efd4550d7926");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pharmacies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "270753dc-0d6b-423d-9801-ff9ae8c08cd5", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "6e12f69a-7dd3-49df-9233-685e42fd90fd", null, "User", "USER" },
                    { "7048cf30-f74d-4a57-8740-3a1ed05a8706", null, "Doctor", "DOCTOR" },
                    { "8b2e2009-8526-401c-bfac-ddfb4e11504b", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "8b98d936-64e3-44d3-899a-2bf01be8409f", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "fc1927a1-c868-4c2e-9064-883acdca5b86", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "a73d9a1d-7316-4d94-a538-3473fe95716c", new DateTime(2025, 3, 13, 0, 54, 38, 369, DateTimeKind.Utc).AddTicks(985), "AQAAAAIAAYagAAAAEMAzfLN34Xhtrye3/KXQUK5GGs1J5tYutoW4p1peJEGIc9d9R6Uxy4r9YB6IeTIrhg==" });
        }
    }
}
