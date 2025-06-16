using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d11e99-cc69-43e4-af0d-c77befc264af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fb4aba1-f6c0-454b-b278-e949a7882bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b785d-cf16-4437-b45e-10daee96dbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fb02a0c-efe5-4249-b7e2-71f495c5a705");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4fcf874-351e-41e3-9991-f513a1c5372e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e56d70fd-5d80-4653-9e20-2b2c9f59aa08");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedEntityId",
                table: "Notifications",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "RelatedEntityType",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notifications",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f493ace-6367-4884-87a4-a66e2ed08a62", null, "Doctor", "DOCTOR" },
                    { "39dbdc90-c1dc-411d-9e4a-21c2f5f408dd", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "5478b920-b9e3-45d1-9ba0-a95d59cc0713", null, "User", "USER" },
                    { "c7c0bf7f-d25f-4b0a-b05e-ac771d200185", null, "Admin", "ADMIN" },
                    { "ea764765-d952-4d9e-8050-02dcb4cdcd11", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "eb11b617-d3e3-4268-8665-6b4063dd759f", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "7c617843-43a9-46bc-8575-c31686a18be5", new DateTime(2025, 6, 16, 6, 57, 15, 172, DateTimeKind.Utc).AddTicks(4119), "AQAAAAIAAYagAAAAEM9IuiZu+EOT5w15/uH5KfYDOkvUXGiS1EjnTwdNfeFxXZ+imli3KeAP1fg+WJUjhQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f493ace-6367-4884-87a4-a66e2ed08a62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39dbdc90-c1dc-411d-9e4a-21c2f5f408dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5478b920-b9e3-45d1-9ba0-a95d59cc0713");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c0bf7f-d25f-4b0a-b05e-ac771d200185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea764765-d952-4d9e-8050-02dcb4cdcd11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb11b617-d3e3-4268-8665-6b4063dd759f");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RelatedEntityType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26d11e99-cc69-43e4-af0d-c77befc264af", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "2fb4aba1-f6c0-454b-b278-e949a7882bc2", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "402b785d-cf16-4437-b45e-10daee96dbbf", null, "Admin", "ADMIN" },
                    { "9fb02a0c-efe5-4249-b7e2-71f495c5a705", null, "User", "USER" },
                    { "b4fcf874-351e-41e3-9991-f513a1c5372e", null, "Doctor", "DOCTOR" },
                    { "e56d70fd-5d80-4653-9e20-2b2c9f59aa08", null, "PharmacyOwner", "PHARMACYOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "25758d7f-0578-42a0-aaa3-0f71a70173d1", new DateTime(2025, 6, 11, 13, 49, 24, 871, DateTimeKind.Utc).AddTicks(6253), "AQAAAAIAAYagAAAAEEKKIWM2Y6l8TdKn4USHB34wLnai+sJAPh7GOAtPbGHNoWu4dMsE2ebKsIJeifwo1w==" });
        }
    }
}
