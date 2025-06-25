using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteForPrescriptionAndPrescriptionProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d11e99-cc69-43e4-af0d-c77befc264af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fb4aba1-f6c0-454b-b278-e949a7882bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b785d-cf16-4437-b45e-10daee96dbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fb02a0c-efe5-4249-b7e2-71f495c5a705");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4fcf874-351e-41e3-9991-f513a1c5372e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e56d70fd-5d80-4653-9e20-2b2c9f59aa08");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductPrescriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Prescriptions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2678149f-0007-403e-a3e2-8c240bcf6b24", null, "Admin", "ADMIN" },
                    { "48887ae6-f317-41dd-a4ab-9b359ef89b92", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "4ce25140-76e7-44e5-b564-3cd0338212d8", null, "User", "USER" },
                    { "a95ff132-7223-4a3b-b5b8-9e0a9d8bc31b", null, "Doctor", "DOCTOR" },
                    { "d1fb82bf-017b-46d3-942c-149aa2475fa9", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "d72b0917-2657-4265-bded-804dcc2c5644", null, "PharmacyManager", "PHARMACYMANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "ca8fb96e-bbdc-432b-a059-11ecf904a720", new DateTime(2025, 6, 19, 12, 39, 41, 377, DateTimeKind.Utc).AddTicks(9892), "AQAAAAIAAYagAAAAEGfdcSblhW8qK0ys6d5baYOS9bahP9oq2bW/1lLGsoECnIVKPOEHzHzxgrxZVwvMfw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2678149f-0007-403e-a3e2-8c240bcf6b24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48887ae6-f317-41dd-a4ab-9b359ef89b92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ce25140-76e7-44e5-b564-3cd0338212d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95ff132-7223-4a3b-b5b8-9e0a9d8bc31b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1fb82bf-017b-46d3-942c-149aa2475fa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d72b0917-2657-4265-bded-804dcc2c5644");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductPrescriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prescriptions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26d11e99-cc69-43e4-af0d-c77befc264af", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "2fb4aba1-f6c0-454b-b278-e949a7882bc2", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "402b785d-cf16-4437-b45e-10daee96dbbf", null, "Admin", "ADMIN" },
                    { "9fb02a0c-efe5-4249-b7e2-71f495c5a705", null, "User", "USER" },
                    { "b4fcf874-351e-41e3-9991-f513a1c5372e", null, "Doctor", "DOCTOR" },
                    { "e56d70fd-5d80-4653-9e20-2b2c9f59aa08", null, "PharmacyOwner", "PHARMACYOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "25758d7f-0578-42a0-aaa3-0f71a70173d1", new DateTime(2025, 6, 11, 13, 49, 24, 871, DateTimeKind.Utc).AddTicks(6253), "AQAAAAIAAYagAAAAEEKKIWM2Y6l8TdKn4USHB34wLnai+sJAPh7GOAtPbGHNoWu4dMsE2ebKsIJeifwo1w==" });
        }
    }
}
