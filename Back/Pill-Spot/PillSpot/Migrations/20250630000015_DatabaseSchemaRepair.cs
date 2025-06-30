using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSchemaRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d7475de9-2a5a-4f82-bad9-f058a4676698", new DateTime(2025, 6, 30, 0, 0, 12, 163, DateTimeKind.Utc).AddTicks(7827), "AQAAAAIAAYagAAAAEM4B7Ki5OG0LzkdawA3iN+Dsg1qzvC/FCFPEYzcNivya/2LhuT+mtKM0hXZzzUV08A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "fc402798-cc97-4f66-8e0b-62f4bb1b8b7b", new DateTime(2025, 6, 29, 7, 13, 54, 107, DateTimeKind.Utc).AddTicks(3628), "AQAAAAIAAYagAAAAELejh6eo6wbVkiOHOZrqIz4riz2FJm5CoWJbbpH3BQNoRmv2G+5E+2C1FWufLDvdyA==" });
        }
    }
}
