using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserFromLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserId",
                table: "Locations");

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
                name: "UserId",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a2b7e50-4414-4be5-b3a4-c6aa707dc1aa", null, "SuperAdmin", "SUPERADMIN" },
                    { "9b7825f9-0ee1-46e5-886b-ebf327df4a61", null, "Doctor", "DOCTOR" },
                    { "ab84d153-a840-484a-a535-4ebd5a40a57f", null, "Admin", "ADMIN" },
                    { "b9ee8b98-c10c-4381-a8d6-044cdaf313f6", null, "User", "USER" },
                    { "e325ecad-cf6f-4b07-bb01-8231a441f772", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "ea5ff1c4-fd1a-4ce4-84cd-d5685e12bf80", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "f0aa8bd6-1134-4a84-b738-81fd7e9218ff", null, "PharmacyOwner", "PHARMACYOWNER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a2b7e50-4414-4be5-b3a4-c6aa707dc1aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b7825f9-0ee1-46e5-886b-ebf327df4a61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab84d153-a840-484a-a535-4ebd5a40a57f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9ee8b98-c10c-4381-a8d6-044cdaf313f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e325ecad-cf6f-4b07-bb01-8231a441f772");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea5ff1c4-fd1a-4ce4-84cd-d5685e12bf80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0aa8bd6-1134-4a84-b738-81fd7e9218ff");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Locations",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AspNetUsers_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
