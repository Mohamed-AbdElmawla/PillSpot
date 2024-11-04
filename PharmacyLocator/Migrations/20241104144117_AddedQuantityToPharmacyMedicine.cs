using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuantityToPharmacyMedicine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c23c965-7d7e-4759-81a0-cdd7f221691d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9916847b-15ef-4a35-b9a7-45f87c4e1dcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daec7da7-8900-4e22-bc3f-a9d194328a34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec660400-3a0e-4172-856f-626036f0842a");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PharmacyMedicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17b5f1fa-14c7-4070-af96-f66f655ac772", null, "Pharmacy", "PHARMACY" },
                    { "7e24f1f5-8896-42e5-86cd-95785ff7c041", null, "Admin", "ADMIN" },
                    { "a746902b-8448-470c-9830-7d4475929968", null, "User", "USER" },
                    { "e221e916-e8ad-4824-a1b2-05dba78672dd", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b5f1fa-14c7-4070-af96-f66f655ac772");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e24f1f5-8896-42e5-86cd-95785ff7c041");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a746902b-8448-470c-9830-7d4475929968");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e221e916-e8ad-4824-a1b2-05dba78672dd");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PharmacyMedicines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c23c965-7d7e-4759-81a0-cdd7f221691d", null, "Admin", "ADMIN" },
                    { "9916847b-15ef-4a35-b9a7-45f87c4e1dcf", null, "User", "USER" },
                    { "daec7da7-8900-4e22-bc3f-a9d194328a34", null, "Pharmacy", "PHARMACY" },
                    { "ec660400-3a0e-4172-856f-626036f0842a", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
