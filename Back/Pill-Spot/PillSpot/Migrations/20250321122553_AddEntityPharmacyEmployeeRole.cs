using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityPharmacyEmployeeRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fae3904-449c-4f59-98fb-a5a3cef215ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a141e06-9d0c-4e4a-8c55-107bbe046348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93e3dbfa-0266-4308-8c4b-5e5b01ecb038");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b44bbb40-e472-42b2-bf17-c37c5faf0f7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7ca10a-099f-4d17-aeb1-c177f3a85940");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efe60b8a-31de-4f1d-a3c0-b020e240a6e4");

            migrationBuilder.CreateTable(
                name: "PharmacyEmployeeRoles",
                columns: table => new
                {
                    employeeRoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PharmacyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyEmployeeRoles", x => x.employeeRoleId);
                    table.ForeignKey(
                        name: "FK_PharmacyEmployeeRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyEmployeeRoles_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyEmployeeRoles_PharmacyEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "PharmacyEmployees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d2e2b76-ddbb-4fc7-bbe7-ed61bbe8938e", null, "Doctor", "DOCTOR" },
                    { "6e70c1fd-77f7-4396-a2b5-4a1d881773a7", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "70a45398-f796-43b0-a8c5-e6a68bc29900", null, "Admin", "ADMIN" },
                    { "7af1fdb9-e972-4ea0-a56b-07f5c1423446", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "7d82bd59-f437-4cb3-876e-ba6cbfd232c4", null, "User", "USER" },
                    { "90c57419-07f8-4de2-92f0-596abc67aad6", null, "PharmacyOwner", "PHARMACYOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "65715dd1-5708-45b3-87f2-d92c534e5697", new DateTime(2025, 3, 21, 12, 25, 49, 716, DateTimeKind.Utc).AddTicks(1092), "AQAAAAIAAYagAAAAEAx5I9qBfg8ZHKLoJKbXgdwRwk2qUkOkPB21UqhAR1J9nX7Ri8g868LPparfmmJBWA==" });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyEmployeeRoles_EmployeeId",
                table: "PharmacyEmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyEmployeeRoles_PharmacyId",
                table: "PharmacyEmployeeRoles",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyEmployeeRoles_RoleId",
                table: "PharmacyEmployeeRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyEmployeeRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2e2b76-ddbb-4fc7-bbe7-ed61bbe8938e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e70c1fd-77f7-4396-a2b5-4a1d881773a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70a45398-f796-43b0-a8c5-e6a68bc29900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af1fdb9-e972-4ea0-a56b-07f5c1423446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d82bd59-f437-4cb3-876e-ba6cbfd232c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90c57419-07f8-4de2-92f0-596abc67aad6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fae3904-449c-4f59-98fb-a5a3cef215ec", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "4a141e06-9d0c-4e4a-8c55-107bbe046348", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "93e3dbfa-0266-4308-8c4b-5e5b01ecb038", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "b44bbb40-e472-42b2-bf17-c37c5faf0f7e", null, "Doctor", "DOCTOR" },
                    { "bc7ca10a-099f-4d17-aeb1-c177f3a85940", null, "Admin", "ADMIN" },
                    { "efe60b8a-31de-4f1d-a3c0-b020e240a6e4", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "5304b998-1bf3-4661-bf46-42585e24c556", new DateTime(2025, 3, 16, 10, 48, 4, 419, DateTimeKind.Utc).AddTicks(804), "AQAAAAIAAYagAAAAEKISuumkqrVetgV/6bS3m/1Vboy2slqZBhmB/FKvJZ8Bf8+qIokwApccSU7Lp20sXA==" });
        }
    }
}
