using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddSmartNotificationFiltering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "426427f0-8522-423a-a893-998cb20e65d6", new DateTime(2025, 6, 28, 22, 29, 16, 420, DateTimeKind.Utc).AddTicks(6158), "AQAAAAIAAYagAAAAEPtgKW6GQdwkclj0CuB2XZImjlOUmevD1MLC81P/vjkkGCOUsBrgCsTXUnZUibdxCQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "9080820d-75a9-432d-a3d4-15db027e429f", new DateTime(2025, 6, 28, 22, 15, 16, 533, DateTimeKind.Utc).AddTicks(173), "AQAAAAIAAYagAAAAEMBxA+2IaARqavGQ7bFqtYWQzPEZx4jobvtnAn0+v+OQCzhk0fn3ngO6smuDwW0tGg==" });
        }
    }
}
