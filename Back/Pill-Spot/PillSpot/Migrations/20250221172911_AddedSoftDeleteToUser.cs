using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeleteToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0676ea4c-56c0-4fba-aa01-005c328740a1", null, "SuperAdmin", "SUPERADMIN" },
                    { "15afc98d-e74e-4da3-abb7-4184495575ac", null, "Doctor", "DOCTOR" },
                    { "1de9849a-1ca5-4e66-ac7e-a14756668701", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "894cf025-12bd-4417-8f4b-968ededfc767", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "a135ddb0-211f-4ca9-b8da-96a62cfb3b69", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "d2745e6a-1216-4654-ac66-b58bb107b4a6", null, "Admin", "ADMIN" },
                    { "ff799f57-c5eb-4a8f-8d29-ef86e835c275", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0676ea4c-56c0-4fba-aa01-005c328740a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15afc98d-e74e-4da3-abb7-4184495575ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1de9849a-1ca5-4e66-ac7e-a14756668701");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "894cf025-12bd-4417-8f4b-968ededfc767");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a135ddb0-211f-4ca9-b8da-96a62cfb3b69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2745e6a-1216-4654-ac66-b58bb107b4a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff799f57-c5eb-4a8f-8d29-ef86e835c275");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

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
    }
}
