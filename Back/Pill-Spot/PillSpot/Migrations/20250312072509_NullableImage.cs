using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class NullableImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "009a2aa6-3a6e-4e12-8e05-314aafa3bf7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f75acf2-054f-4316-9fab-76394cdf923d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17359633-24ac-494c-afe2-ea97877d22f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff223b6-0be8-4cda-8804-23f6a862a2fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e72a24b-8393-404a-b246-8b97274151e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed4d9e08-9f15-4343-9292-205531ed35b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f855bb93-c683-4b6a-81d7-2f3a2dce578c");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0abdc91d-7750-4c6e-9af5-19c0cc009d15", null, "SuperAdmin", "SUPERADMIN" },
                    { "18002497-14e6-4270-b05b-6a6b2238101d", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "40922e9b-8a67-4162-be1f-f7853824119f", null, "User", "USER" },
                    { "5ea9a852-40a8-4b34-ba56-a2cad143ce43", null, "Admin", "ADMIN" },
                    { "70dea4e2-a6dc-44f9-be95-bb362b93a1ce", null, "Doctor", "DOCTOR" },
                    { "72964706-5e2b-40f8-baba-ff38ab6a0c26", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "da1f8694-7005-49d9-b6dc-ccdc8644cdef", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0abdc91d-7750-4c6e-9af5-19c0cc009d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18002497-14e6-4270-b05b-6a6b2238101d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40922e9b-8a67-4162-be1f-f7853824119f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea9a852-40a8-4b34-ba56-a2cad143ce43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70dea4e2-a6dc-44f9-be95-bb362b93a1ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72964706-5e2b-40f8-baba-ff38ab6a0c26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da1f8694-7005-49d9-b6dc-ccdc8644cdef");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ImageURL",
                keyValue: null,
                column: "ImageURL",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "009a2aa6-3a6e-4e12-8e05-314aafa3bf7e", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "0f75acf2-054f-4316-9fab-76394cdf923d", null, "Admin", "ADMIN" },
                    { "17359633-24ac-494c-afe2-ea97877d22f6", null, "SuperAdmin", "SUPERADMIN" },
                    { "1ff223b6-0be8-4cda-8804-23f6a862a2fb", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "8e72a24b-8393-404a-b246-8b97274151e7", null, "Doctor", "DOCTOR" },
                    { "ed4d9e08-9f15-4343-9292-205531ed35b0", null, "User", "USER" },
                    { "f855bb93-c683-4b6a-81d7-2f3a2dce578c", null, "PharmacyOwner", "PHARMACYOWNER" }
                });
        }
    }
}
