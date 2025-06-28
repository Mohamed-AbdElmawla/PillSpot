using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestNotificationSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f680303d-6380-492a-b006-72e4fb6e4645", new DateTime(2025, 6, 28, 22, 48, 10, 688, DateTimeKind.Utc).AddTicks(2975), "AQAAAAIAAYagAAAAEMzVvt8exVawWFCAXQgReU3CID2fWy9DmgSEUiLo/CEZg2lIbib5JMEmIOTF4irftw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "426427f0-8522-423a-a893-998cb20e65d6", new DateTime(2025, 6, 28, 22, 29, 16, 420, DateTimeKind.Utc).AddTicks(6158), "AQAAAAIAAYagAAAAEPtgKW6GQdwkclj0CuB2XZImjlOUmevD1MLC81P/vjkkGCOUsBrgCsTXUnZUibdxCQ==" });
        }
    }
}
