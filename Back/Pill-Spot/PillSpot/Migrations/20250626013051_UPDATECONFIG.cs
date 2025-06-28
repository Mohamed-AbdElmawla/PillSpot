using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UPDATECONFIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "cd7199ab-27d0-4dc0-9314-eac8c51967d4", new DateTime(2025, 6, 26, 1, 30, 46, 635, DateTimeKind.Utc).AddTicks(6847), "AQAAAAIAAYagAAAAEKTuwKFWy8CYIEYjE/lyHzAPjAlD68UtiJVKbsuoieUzwyo8Onn8yI4jt1W3gpSDDA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8a4afe0c-0a12-4c86-a3e2-c591ece73fe3", new DateTime(2025, 6, 26, 1, 3, 16, 229, DateTimeKind.Utc).AddTicks(5835), "AQAAAAIAAYagAAAAEOClmbjk4863AlqyFWsv154SBuFE8c1R1Q9UunQBawcUH1KzNl6wD6wuDCK8+d09xg==" });
        }
    }
}
