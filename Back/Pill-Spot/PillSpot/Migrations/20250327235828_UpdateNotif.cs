using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2e2b76-ddbb-4fc7-bbe7-ed61bbe8938e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e70c1fd-77f7-4396-a2b5-4a1d881773a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70a45398-f796-43b0-a8c5-e6a68bc29900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af1fdb9-e972-4ea0-a56b-07f5c1423446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d82bd59-f437-4cb3-876e-ba6cbfd232c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90c57419-07f8-4de2-92f0-596abc67aad6");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "172e9041-5908-4352-a4e0-e6596018c878", null, "User", "USER" },
                    { "5fa8717f-b927-4e75-8376-893239626d8e", null, "Admin", "ADMIN" },
                    { "67b0437b-ebb4-4a20-a312-d05c2d781c75", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "6a05d1a3-098d-44bb-a292-7cd51bdca426", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "b1325d6e-92d5-4c74-84ba-c91aa11c1193", null, "Doctor", "DOCTOR" },
                    { "cd783f2e-1f40-430e-8499-84ac98389053", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "8af34bb5-b8d6-488a-a9d8-4ba0aece4d7b", new DateTime(2025, 3, 27, 23, 58, 20, 722, DateTimeKind.Utc).AddTicks(5365), "AQAAAAIAAYagAAAAEJjlwBUJuYIQwmIw5lv2S8VMGcjmIqD+3vGh+B0tIjF+/LKsDkCzHFdoCxh+qCpibw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "172e9041-5908-4352-a4e0-e6596018c878");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fa8717f-b927-4e75-8376-893239626d8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67b0437b-ebb4-4a20-a312-d05c2d781c75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a05d1a3-098d-44bb-a292-7cd51bdca426");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1325d6e-92d5-4c74-84ba-c91aa11c1193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd783f2e-1f40-430e-8499-84ac98389053");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d2e2b76-ddbb-4fc7-bbe7-ed61bbe8938e", null, "Doctor", "DOCTOR" },
                    { "6e70c1fd-77f7-4396-a2b5-4a1d881773a7", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "70a45398-f796-43b0-a8c5-e6a68bc29900", null, "Admin", "ADMIN" },
                    { "7af1fdb9-e972-4ea0-a56b-07f5c1423446", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "7d82bd59-f437-4cb3-876e-ba6cbfd232c4", null, "User", "USER" },
                    { "90c57419-07f8-4de2-92f0-596abc67aad6", null, "PharmacyOwner", "PHARMACYOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "65715dd1-5708-45b3-87f2-d92c534e5697", new DateTime(2025, 3, 21, 12, 25, 49, 716, DateTimeKind.Utc).AddTicks(1092), "AQAAAAIAAYagAAAAEAx5I9qBfg8ZHKLoJKbXgdwRwk2qUkOkPB21UqhAR1J9nX7Ri8g868LPparfmmJBWA==" });
        }
    }
}
