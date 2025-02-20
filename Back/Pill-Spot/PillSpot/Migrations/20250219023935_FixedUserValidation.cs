using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3186750a-8d81-43fd-b4dc-42d7a8e3f621");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4181afd1-b3bb-4c29-b6ac-a1c105042eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "795ec8e9-a946-4394-bfad-5d3fde98149e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8140aa22-0894-47da-8b95-39bbc60d4cff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d3c34dc-a522-4aac-ad44-92d36a6f4e4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0851248-1355-480c-8c80-5c4799713414");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb1e5088-23c3-466c-b1ce-1e477413a9c1");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "LocationID",
                table: "AspNetUsers",
                type: "bigint unsigned",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "AspNetUsers",
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
                    { "34cf6774-46b2-4641-9739-2e576b71dc3f", null, "Admin", "ADMIN" },
                    { "54947764-11b7-4a4e-ade0-25dbcbc478d5", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "56507e4e-849f-4847-92d6-affeae0430eb", null, "User", "USER" },
                    { "6c24d4cf-e270-4852-93f5-b1c04229d8f9", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "761e5d65-aa81-4bf0-b48a-d2e9d6cd0163", null, "SuperAdmin", "SUPERADMIN" },
                    { "d01b403b-6c34-4662-b04a-0bc9e6856bfe", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "dc932640-818d-4035-833d-5e6cd6960845", null, "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34cf6774-46b2-4641-9739-2e576b71dc3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54947764-11b7-4a4e-ade0-25dbcbc478d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56507e4e-849f-4847-92d6-affeae0430eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c24d4cf-e270-4852-93f5-b1c04229d8f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "761e5d65-aa81-4bf0-b48a-d2e9d6cd0163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d01b403b-6c34-4662-b04a-0bc9e6856bfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc932640-818d-4035-833d-5e6cd6960845");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "RefreshToken",
                keyValue: null,
                column: "RefreshToken",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<ulong>(
                name: "LocationID",
                table: "AspNetUsers",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ImageURL",
                keyValue: null,
                column: "ImageURL",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "AspNetUsers",
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
                    { "3186750a-8d81-43fd-b4dc-42d7a8e3f621", null, "User", "USER" },
                    { "4181afd1-b3bb-4c29-b6ac-a1c105042eb9", null, "Doctor", "DOCTOR" },
                    { "795ec8e9-a946-4394-bfad-5d3fde98149e", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "8140aa22-0894-47da-8b95-39bbc60d4cff", null, "Admin", "ADMIN" },
                    { "9d3c34dc-a522-4aac-ad44-92d36a6f4e4a", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "f0851248-1355-480c-8c80-5c4799713414", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "fb1e5088-23c3-466c-b1ce-1e477413a9c1", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
