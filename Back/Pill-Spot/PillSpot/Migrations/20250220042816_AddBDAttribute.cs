using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddBDAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "AspNetUsers",
                newName: "ProfilePictureUrl");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19301c17-5706-4a2b-9cd4-979f30dba5c3", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "33aee400-168f-40a4-9eed-5378fc24b2b8", null, "Doctor", "DOCTOR" },
                    { "5815d0a8-1f1d-457c-931d-89163fa32912", null, "Admin", "ADMIN" },
                    { "962b52ff-bd2e-4b35-ae67-b2f6dd991574", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "b76d70c0-85a3-417b-844e-eb13fe561cf4", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "d3b37367-19d6-4609-867a-a6621aeb2da9", null, "SuperAdmin", "SUPERADMIN" },
                    { "fcf012c3-9ac6-4d43-a46a-3d47a93d6d91", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19301c17-5706-4a2b-9cd4-979f30dba5c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33aee400-168f-40a4-9eed-5378fc24b2b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5815d0a8-1f1d-457c-931d-89163fa32912");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962b52ff-bd2e-4b35-ae67-b2f6dd991574");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b76d70c0-85a3-417b-844e-eb13fe561cf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b37367-19d6-4609-867a-a6621aeb2da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf012c3-9ac6-4d43-a46a-3d47a93d6d91");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                newName: "ImageURL");

            migrationBuilder.AddColumn<short>(
                name: "Age",
                table: "AspNetUsers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

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
    }
}
