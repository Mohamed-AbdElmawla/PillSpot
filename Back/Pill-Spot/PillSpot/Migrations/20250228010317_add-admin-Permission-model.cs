using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class addadminPermissionmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AdminPermissions",
                columns: table => new
                {
                    AdminID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPermissions", x => new { x.AdminID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_AdminPermissions_AspNetUsers_AdminID",
                        column: x => x.AdminID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminPermissions_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "003e0f19-3899-478f-aa87-5b405a27493e", null, "User", "USER" },
                    { "1bbfa767-45f8-4b10-b6bb-1b498540651c", null, "Doctor", "DOCTOR" },
                    { "5a51c3ac-4fbf-494d-a16a-31b92d25d541", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "83f89199-38ef-491a-bb27-276887ceff17", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "a24aca07-460b-4557-9fa8-7d1bb60a0cb1", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "bde81543-8779-481f-b77a-e21d6f8a6655", null, "Admin", "ADMIN" },
                    { "fd80db25-ff85-4826-be1d-2dae2603b199", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminPermission_AdminID_PermissionID",
                table: "AdminPermissions",
                columns: new[] { "AdminID", "PermissionID" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminPermissions_PermissionID",
                table: "AdminPermissions",
                column: "PermissionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminPermissions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003e0f19-3899-478f-aa87-5b405a27493e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bbfa767-45f8-4b10-b6bb-1b498540651c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a51c3ac-4fbf-494d-a16a-31b92d25d541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f89199-38ef-491a-bb27-276887ceff17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24aca07-460b-4557-9fa8-7d1bb60a0cb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde81543-8779-481f-b77a-e21d6f8a6655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd80db25-ff85-4826-be1d-2dae2603b199");

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
    }
}
