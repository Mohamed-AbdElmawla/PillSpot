using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class Addpointtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090aed34-47d8-48a1-865a-a3f7358bc73a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1366209a-8354-418d-8e05-b3b65dc38511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "405ba782-c051-487a-8157-361b37485a20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59aab37b-063f-4abd-a174-9678a552349e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc5639d-4985-4e64-b5dd-fe759d2bb3b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bf58f40-6a0d-466d-8a51-fabc21b4a629");

            migrationBuilder.AddColumn<Point>(
                name: "Geography",
                table: "Locations",
                type: "point",
                nullable: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b6bbe0d-9cc2-4052-b3d6-06a12751dffd", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "5cb1a5a5-d400-4ec2-9757-72fee3e4c86d", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "9993976c-2a33-42ed-93cd-425940f5d7e8", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "bbd41ff0-f293-48e6-b1f6-932e6908586f", null, "Doctor", "DOCTOR" },
                    { "ec737f9a-20a8-4ee6-a957-19f0645ae0e4", null, "Admin", "ADMIN" },
                    { "ef628bc4-4f95-4b84-b8c3-a3cd9fc18d51", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "ce79acdb-4c8f-460d-8a23-df222b87d087", new DateTime(2025, 5, 3, 1, 18, 58, 743, DateTimeKind.Utc).AddTicks(2960), "AQAAAAIAAYagAAAAEAWgPwM6Cdwgwb+819a87V7utWq2tIN4lUOGsN0nbbfYlII7n7+ACoLCsF+/lgt+Hg==" });

            migrationBuilder.CreateIndex(
                name: "SpatialIndex_Location_Geography",
                table: "Locations",
                column: "Geography")
                .Annotation("MySql:SpatialIndex", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "SpatialIndex_Location_Geography",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6bbe0d-9cc2-4052-b3d6-06a12751dffd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb1a5a5-d400-4ec2-9757-72fee3e4c86d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9993976c-2a33-42ed-93cd-425940f5d7e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbd41ff0-f293-48e6-b1f6-932e6908586f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec737f9a-20a8-4ee6-a957-19f0645ae0e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef628bc4-4f95-4b84-b8c3-a3cd9fc18d51");

            migrationBuilder.DropColumn(
                name: "Geography",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "090aed34-47d8-48a1-865a-a3f7358bc73a", null, "Doctor", "DOCTOR" },
                    { "1366209a-8354-418d-8e05-b3b65dc38511", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "405ba782-c051-487a-8157-361b37485a20", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "59aab37b-063f-4abd-a174-9678a552349e", null, "User", "USER" },
                    { "5bc5639d-4985-4e64-b5dd-fe759d2bb3b9", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "5bf58f40-6a0d-466d-8a51-fabc21b4a629", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "4c96ca4f-6d1b-4c6f-a918-bb038b4c3dee", new DateTime(2025, 5, 3, 1, 6, 34, 934, DateTimeKind.Utc).AddTicks(9315), "AQAAAAIAAYagAAAAEDShoikf9vq7Bt5vaLOdrB/7CLLQjrG5i3CT5JLYS/y+IHiLMBXCJpVoTDEoSX5zJQ==" });
        }
    }
}
