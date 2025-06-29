using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTypesToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8b55f1c5-e6ad-41a3-b22c-b56a803bfc24", new DateTime(2025, 6, 29, 23, 27, 6, 228, DateTimeKind.Utc).AddTicks(3850), "AQAAAAIAAYagAAAAEFVEpfFFjusrFyw0mhoCu1Zy5RD0NVRsRYh3xwjhLBToU/JQOppDpnweiCIbXHfmIQ==" });
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
