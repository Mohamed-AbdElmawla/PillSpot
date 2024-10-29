using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyLocator.Migrations
{
    /// <inheritdoc />
    public partial class EditInUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2519e081-a3c0-4222-8ce8-96f40a0c3225");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3798348a-188e-4fe6-8208-293e39e50763");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55329e53-4533-43fb-a5eb-7097c22c131b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70276ea3-af95-474a-8966-17afa8173e08");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e1e085-6458-40e6-a54c-19020732b4c9", null, "SuperAdmin", "SUPERADMIN" },
                    { "1b5ce77a-76f8-417c-8b90-96bcff3211d0", null, "User", "USER" },
                    { "732e5901-8798-4c75-bd3d-22caa46a4d1d", null, "Pharmacy", "PHARMACY" },
                    { "d0e6ed3e-6a5d-4e5f-b336-cb570b860e6b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e1e085-6458-40e6-a54c-19020732b4c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5ce77a-76f8-417c-8b90-96bcff3211d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732e5901-8798-4c75-bd3d-22caa46a4d1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e6ed3e-6a5d-4e5f-b336-cb570b860e6b");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2519e081-a3c0-4222-8ce8-96f40a0c3225", null, "User", "USER" },
                    { "3798348a-188e-4fe6-8208-293e39e50763", null, "Admin", "ADMIN" },
                    { "55329e53-4533-43fb-a5eb-7097c22c131b", null, "SuperAdmin", "SUPERADMIN" },
                    { "70276ea3-af95-474a-8966-17afa8173e08", null, "Pharmacy", "PHARMACY" }
                });
        }
    }
}
