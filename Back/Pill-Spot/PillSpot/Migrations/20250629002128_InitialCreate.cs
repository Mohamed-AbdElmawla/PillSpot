using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyProductNotificationPreferences",
                columns: table => new
                {
                    PreferenceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<string>(type: "varchar(450)", maxLength: 450, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PharmacyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    NotificationTypes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "(UTC_TIMESTAMP())"),
                    LastNotifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProductNotificationPreferences", x => x.PreferenceId);
                    table.ForeignKey(
                        name: "FK_PharmacyProductNotificationPreferences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyProductNotificationPreferences_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PharmacyProductNotificationPreferences_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "e9c5828b-1efa-49ca-b938-655d63ce92cf", new DateTime(2025, 6, 29, 0, 21, 21, 845, DateTimeKind.Utc).AddTicks(4157), "AQAAAAIAAYagAAAAELxRzXd0AR8XfJFBXySmngS9cWdphWRLdmABBFlqUr7xdvaS4bfdjCmTd/MJD6YJVA==" });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductNotificationPreference_IsEnabled",
                table: "PharmacyProductNotificationPreferences",
                column: "IsEnabled");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductNotificationPreference_PharmacyId",
                table: "PharmacyProductNotificationPreferences",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductNotificationPreference_ProductId",
                table: "PharmacyProductNotificationPreferences",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductNotificationPreference_User_Product_Pharmacy",
                table: "PharmacyProductNotificationPreferences",
                columns: new[] { "UserId", "ProductId", "PharmacyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductNotificationPreference_UserId",
                table: "PharmacyProductNotificationPreferences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyProductNotificationPreferences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f680303d-6380-492a-b006-72e4fb6e4645", new DateTime(2025, 6, 28, 22, 48, 10, 688, DateTimeKind.Utc).AddTicks(2975), "AQAAAAIAAYagAAAAEMzVvt8exVawWFCAXQgReU3CID2fWy9DmgSEUiLo/CEZg2lIbib5JMEmIOTF4irftw==" });
        }
    }
}
