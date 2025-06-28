using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddPharmacyProductUpdateFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "9080820d-75a9-432d-a3d4-15db027e429f", new DateTime(2025, 6, 28, 22, 15, 16, 533, DateTimeKind.Utc).AddTicks(173), "AQAAAAIAAYagAAAAEMBxA+2IaARqavGQ7bFqtYWQzPEZx4jobvtnAn0+v+OQCzhk0fn3ngO6smuDwW0tGg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "fa237d94-3a25-464f-be6d-30e9da0a86da", new DateTime(2025, 6, 28, 21, 59, 23, 199, DateTimeKind.Utc).AddTicks(6951), "AQAAAAIAAYagAAAAEOmefTndR/i4UkAwsshiUoQFPk8GOQGRNRcJZfJTnw6SYIYqFLj4M9BzIwDL5ijQww==" });
        }
    }
}
