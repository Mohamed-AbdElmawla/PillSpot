using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturerToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8a4afe0c-0a12-4c86-a3e2-c591ece73fe3", new DateTime(2025, 6, 26, 1, 3, 16, 229, DateTimeKind.Utc).AddTicks(5835), "AQAAAAIAAYagAAAAEOClmbjk4863AlqyFWsv154SBuFE8c1R1Q9UunQBawcUH1KzNl6wD6wuDCK8+d09xg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "a7c5ab5c-1498-4bcc-8da1-cb5ed04b1ae1", new DateTime(2025, 6, 26, 0, 51, 22, 869, DateTimeKind.Utc).AddTicks(8226), "AQAAAAIAAYagAAAAEOY9vrMUxxLGQ/0FfELvJ0ZlNXsb2tvkMqtTM7LUE2953MlbwfxfHfzuFmENbKdwMA==" });
        }
    }
}
