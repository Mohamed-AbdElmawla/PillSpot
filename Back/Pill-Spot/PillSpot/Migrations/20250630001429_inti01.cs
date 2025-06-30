using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class inti01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "e696d45d-47b2-47a0-9de9-1fc198b95d7e", new DateTime(2025, 6, 30, 0, 14, 28, 547, DateTimeKind.Utc).AddTicks(3186), "AQAAAAIAAYagAAAAED4Z0q6dPU6BPwAQDh+tFEb/kpUxoB4Jy0FRSEbC4vchD5hxGsOm5q821IHBrcjyYA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "d7475de9-2a5a-4f82-bad9-f058a4676698", new DateTime(2025, 6, 30, 0, 0, 12, 163, DateTimeKind.Utc).AddTicks(7827), "AQAAAAIAAYagAAAAEM4B7Ki5OG0LzkdawA3iN+Dsg1qzvC/FCFPEYzcNivya/2LhuT+mtKM0hXZzzUV08A==" });
        }
    }
}
