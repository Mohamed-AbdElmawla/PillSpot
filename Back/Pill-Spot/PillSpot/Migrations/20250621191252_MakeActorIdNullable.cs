using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class MakeActorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActorId",
                table: "Notifications",
                type: "varchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldMaxLength: 450)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "bdb3998d-8f88-46d6-973a-52ff491073a8", new DateTime(2025, 6, 21, 19, 12, 38, 339, DateTimeKind.Utc).AddTicks(475), "AQAAAAIAAYagAAAAELMLHOoP1rYoSQ9TPcTu3zBkJCTpOdSHzBsxZVkpUIEUT170Gm4dbxZksm1wH07ISg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "ActorId",
                keyValue: null,
                column: "ActorId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ActorId",
                table: "Notifications",
                type: "varchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldMaxLength: 450,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "c8c8c14c-9c4b-4b56-97e4-c46804687185", new DateTime(2025, 6, 19, 22, 16, 41, 637, DateTimeKind.Utc).AddTicks(8389), "AQAAAAIAAYagAAAAECrvPyaWIrIcAqtndFigRWqUnlUm2F54zc/3O0gdFWzgwQxAjpzYYjOYzhUWqbxQ2g==" });
        }
    }
}
