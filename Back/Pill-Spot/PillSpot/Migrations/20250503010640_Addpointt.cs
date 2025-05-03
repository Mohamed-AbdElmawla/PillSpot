using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class Addpointt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "SpatialIndex_Location_Geography",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a94d8bd-6a2b-4a8d-877b-98df28ce68a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0acea651-44fc-4d6a-8aaa-5d17c51ff2a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26faadff-2411-4d12-a9d8-697599715064");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4340e999-062b-43ae-aeee-519b19a8945e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f3da4b-a14d-43cb-89ff-749cb0b63e14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9a02a9-06d2-473a-abd5-698e6cf39dae");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0a94d8bd-6a2b-4a8d-877b-98df28ce68a7", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "0acea651-44fc-4d6a-8aaa-5d17c51ff2a6", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "26faadff-2411-4d12-a9d8-697599715064", null, "Admin", "ADMIN" },
                    { "4340e999-062b-43ae-aeee-519b19a8945e", null, "Doctor", "DOCTOR" },
                    { "80f3da4b-a14d-43cb-89ff-749cb0b63e14", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "ee9a02a9-06d2-473a-abd5-698e6cf39dae", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin-user-id1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "0dafcd25-192f-4f2d-8856-74c1e8875077", new DateTime(2025, 5, 3, 0, 36, 28, 519, DateTimeKind.Utc).AddTicks(4933), "AQAAAAIAAYagAAAAEId6rg1LahTVAmKtr/vUMUc4WJFDSPb5jjhKH0T8dDKJavNH1Dugq0+stQj4w3MZVQ==" });

            migrationBuilder.CreateIndex(
                name: "SpatialIndex_Location_Geography",
                table: "Locations",
                column: "Geography")
                .Annotation("MySql:SpatialIndex", true);
        }
    }
}
