using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class updateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ba88e98-9678-4552-97f4-3878c3709373", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "459bd42e-071e-4ca5-bdcf-630a3b5a1a93", null, "Admin", "ADMIN" },
                    { "545ce437-3d25-49bf-91e8-63a4d3f66c37", null, "Doctor", "DOCTOR" },
                    { "b67106ba-e33d-4349-9899-ada9b7450b2a", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "bf57d2b0-f89f-40fe-8ca6-13a86d875670", null, "SuperAdmin", "SUPERADMIN" },
                    { "e41947c6-5470-4369-bc76-b52af8a60f1c", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "ebaff91e-2f8e-45b3-8e2c-9dcfa8b9bb83", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba88e98-9678-4552-97f4-3878c3709373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "459bd42e-071e-4ca5-bdcf-630a3b5a1a93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "545ce437-3d25-49bf-91e8-63a4d3f66c37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b67106ba-e33d-4349-9899-ada9b7450b2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf57d2b0-f89f-40fe-8ca6-13a86d875670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41947c6-5470-4369-bc76-b52af8a60f1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebaff91e-2f8e-45b3-8e2c-9dcfa8b9bb83");

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
    }
}
