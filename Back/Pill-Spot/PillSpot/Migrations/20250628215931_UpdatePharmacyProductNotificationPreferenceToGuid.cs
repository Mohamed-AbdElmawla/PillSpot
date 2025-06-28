using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePharmacyProductNotificationPreferenceToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "fa237d94-3a25-464f-be6d-30e9da0a86da", new DateTime(2025, 6, 28, 21, 59, 23, 199, DateTimeKind.Utc).AddTicks(6951), "AQAAAAIAAYagAAAAEOmefTndR/i4UkAwsshiUoQFPk8GOQGRNRcJZfJTnw6SYIYqFLj4M9BzIwDL5ijQww==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "cd7199ab-27d0-4dc0-9314-eac8c51967d4", new DateTime(2025, 6, 26, 1, 30, 46, 635, DateTimeKind.Utc).AddTicks(6847), "AQAAAAIAAYagAAAAEKTuwKFWy8CYIEYjE/lyHzAPjAlD68UtiJVKbsuoieUzwyo8Onn8yI4jt1W3gpSDDA==" });
        }
    }
}
