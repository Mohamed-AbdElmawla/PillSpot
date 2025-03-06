using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PillSpot.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPharmacyProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminPermissions_AspNetUsers_AdminID",
                table: "AdminPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminPermissions_Permissions_PermissionID",
                table: "AdminPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Products_ProductID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorFeedbacks_Doctors_UserID",
                table: "DoctorFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorFeedbacks_Feedbacks_FeedbackID",
                table: "DoctorFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPrescriptions_AspNetUsers_UserID",
                table: "DoctorPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPrescriptions_Prescriptions_PrescriptionID",
                table: "DoctorPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_SenderID",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Products_ProductID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Pharmacies_PharmacyBranchID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_LocationID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_OwnerID",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Locations_LocationID",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Pharmacies_ParentPharmacyID",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeePermissions_Permissions_PermissionID",
                table: "PharmacyEmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeePermissions_PharmacyEmployees_EmployeeID",
                table: "PharmacyEmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployees_AspNetUsers_UserID",
                table: "PharmacyEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployees_Pharmacies_PharmacyID",
                table: "PharmacyEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyFeedbacks_Feedbacks_FeedbackID",
                table: "PharmacyFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyFeedbacks_Pharmacies_PharmacyID",
                table: "PharmacyFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_AdminUserID",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_UserID",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_Locations_LocationID",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientsID",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Products_ProductID",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchID",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchID1",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Pharmacies_PharmacyID",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Products_ProductID",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescriptions_Prescriptions_PrescriptionID",
                table: "ProductPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescriptions_Products_ProductID",
                table: "ProductPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Supports_AspNetUsers_UserID",
                table: "Supports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_AspNetUsers_UserID",
                table: "UserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationID",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrescriptions_AspNetUsers_UserID",
                table: "UserPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrescriptions_Prescriptions_PrescriptionID",
                table: "UserPrescriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "041ae8c2-6891-43b9-ad80-0a1fadc18bc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34411420-9350-4a7d-92c0-8bf8723f2573");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "614ab8c3-62b8-4c1b-825d-2f9dcae43e6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93f897e7-cd57-4013-b8e6-1af65ec463b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b57a932d-f05a-41dd-be74-4f71686cadbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be08fa48-ed43-424c-9e7f-338699ad53e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3c6c020-0cf1-46ef-a083-a3142cced27b");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserPrescriptions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PrescriptionID",
                table: "UserPrescriptions",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPrescriptions_UserID",
                table: "UserPrescriptions",
                newName: "IX_UserPrescriptions_UserId");

            migrationBuilder.RenameColumn(
                name: "NotificationID",
                table: "UserNotifications",
                newName: "NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotifications_NotificationID",
                table: "UserNotifications",
                newName: "IX_UserNotifications_NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotification_ReceiverId_NotificationID",
                table: "UserNotifications",
                newName: "IX_UserNotification_ReceiverId_NotificationId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserChats",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChat_UserID_ChatId",
                table: "UserChats",
                newName: "IX_UserChat_UserId_ChatId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Supports",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SupportID",
                table: "Supports",
                newName: "SupportId");

            migrationBuilder.RenameIndex(
                name: "IX_Support_UserID",
                table: "Supports",
                newName: "IX_Support_UserId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "SubCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "SubCategories",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "Products",
                newName: "SubCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                newName: "IX_Products_SubCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductPrescriptions",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PrescriptionID",
                table: "ProductPrescriptions",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrescriptions_ProductID",
                table: "ProductPrescriptions",
                newName: "IX_ProductPrescriptions_ProductId");

            migrationBuilder.RenameColumn(
                name: "BatchID1",
                table: "ProductPharmacies",
                newName: "BatchId1");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                table: "ProductPharmacies",
                newName: "BatchId");

            migrationBuilder.RenameColumn(
                name: "PharmacyID",
                table: "ProductPharmacies",
                newName: "PharmacyId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductPharmacies",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacy_ProductID_PharmacyID",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacy_ProductId_PharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_PharmacyID",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_PharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_BatchID1",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_BatchId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_BatchID",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_BatchId");

            migrationBuilder.RenameColumn(
                name: "IngredientsID",
                table: "ProductIngredients",
                newName: "IngredientsId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductIngredients",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredients_IngredientsID",
                table: "ProductIngredients",
                newName: "IX_ProductIngredients_IngredientsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredient_ProductID_IngredientsID",
                table: "ProductIngredients",
                newName: "IX_ProductIngredient_ProductId_IngredientsId");

            migrationBuilder.RenameColumn(
                name: "PrescriptionID",
                table: "Prescriptions",
                newName: "PrescriptionId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "PharmacyRequest",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "PharmacyRequest",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "LicenseID",
                table: "PharmacyRequest",
                newName: "LicenseId");

            migrationBuilder.RenameColumn(
                name: "AdminUserID",
                table: "PharmacyRequest",
                newName: "AdminUserId");

            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "PharmacyRequest",
                newName: "RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_UserID",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_LocationID",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_AdminUserID",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_AdminUserId");

            migrationBuilder.RenameColumn(
                name: "PharmacyID",
                table: "PharmacyFeedbacks",
                newName: "PharmacyId");

            migrationBuilder.RenameColumn(
                name: "FeedbackID",
                table: "PharmacyFeedbacks",
                newName: "FeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyFeedback_PharmacyID",
                table: "PharmacyFeedbacks",
                newName: "IX_PharmacyFeedback_PharmacyId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "PharmacyEmployees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PharmacyID",
                table: "PharmacyEmployees",
                newName: "PharmacyId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "PharmacyEmployees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployees_PharmacyID",
                table: "PharmacyEmployees",
                newName: "IX_PharmacyEmployees_PharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployee_UserID_PharmacyID",
                table: "PharmacyEmployees",
                newName: "IX_PharmacyEmployee_UserId_PharmacyId");

            migrationBuilder.RenameColumn(
                name: "PermissionID",
                table: "PharmacyEmployeePermissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "PharmacyEmployeePermissions",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployeePermissions_PermissionID",
                table: "PharmacyEmployeePermissions",
                newName: "IX_PharmacyEmployeePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployeePermission_EmployeeID_PermissionID",
                table: "PharmacyEmployeePermissions",
                newName: "IX_PharmacyEmployeePermission_EmployeeId_PermissionId");

            migrationBuilder.RenameColumn(
                name: "ParentPharmacyID",
                table: "Pharmacies",
                newName: "ParentPharmacyId");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Pharmacies",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Pharmacies",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "LicenseID",
                table: "Pharmacies",
                newName: "LicenseId");

            migrationBuilder.RenameColumn(
                name: "PharmacyID",
                table: "Pharmacies",
                newName: "PharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_ParentPharmacyID",
                table: "Pharmacies",
                newName: "IX_Pharmacies_ParentPharmacyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_OwnerID",
                table: "Pharmacies",
                newName: "IX_Pharmacies_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_LocationID",
                table: "Pharmacies",
                newName: "IX_Pharmacies_LocationId");

            migrationBuilder.RenameColumn(
                name: "PermissionID",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Orders",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_LocationID",
                table: "Orders",
                newName: "IX_Orders_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserID",
                table: "Orders",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PharmacyBranchID",
                table: "OrderItems",
                newName: "PharmacyBranchId");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderItemID",
                table: "OrderItems",
                newName: "OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_PharmacyBranchID",
                table: "OrderItems",
                newName: "IX_OrderItems_PharmacyBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderID_ProductID",
                table: "OrderItems",
                newName: "IX_OrderItem_OrderId_ProductId");

            migrationBuilder.RenameColumn(
                name: "NotificationID",
                table: "Notifications",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Medicines",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Locations",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "IngredientsID",
                table: "Ingredients",
                newName: "IngredientsId");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Feedbacks",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "FeedbackID",
                table: "Feedbacks",
                newName: "FeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_SenderID",
                table: "Feedbacks",
                newName: "IX_Feedback_SenderId");

            migrationBuilder.RenameColumn(
                name: "LicenseID",
                table: "Doctors",
                newName: "LicenseId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Doctors",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor_LicenseID",
                table: "Doctors",
                newName: "IX_Doctor_LicenseId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "DoctorPrescriptions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PrescriptionID",
                table: "DoctorPrescriptions",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_DP_UsrID",
                table: "DoctorPrescriptions",
                newName: "IX_DP_UsrId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "DoctorFeedbacks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FeedbackID",
                table: "DoctorFeedbacks",
                newName: "FeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorFeedback_UserID",
                table: "DoctorFeedbacks",
                newName: "IX_DoctorFeedback_UserId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Cosmetics",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "BatchID",
                table: "Batches",
                newName: "BatchId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "AspNetUsers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LocationID",
                table: "AspNetUsers",
                newName: "IX_User_LocationId");

            migrationBuilder.RenameColumn(
                name: "PermissionID",
                table: "AdminPermissions",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "AdminPermissions",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminPermissions_PermissionID",
                table: "AdminPermissions",
                newName: "IX_AdminPermissions_PermissionId");

            migrationBuilder.AlterColumn<ulong>(
                name: "PharmacyId",
                table: "ProductPharmacies",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<ulong>(
                name: "ProductId",
                table: "ProductPharmacies",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "288e5a5f-9c42-4cca-8621-5e4915d8018f", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "37649a5e-27a9-4136-9371-7cc045ed1f15", null, "PharmacyOwner", "PHARMACYOWNER" },
                    { "5887ffbb-44d4-45bb-a52e-459eb39709d4", null, "SuperAdmin", "SUPERADMIN" },
                    { "8d1c4b89-3d85-4931-aa3f-7ca2e4cc54fa", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "f19d4518-7480-46ba-a872-106b11d12350", null, "User", "USER" },
                    { "f1e3bf27-bcd1-4956-968a-6a06fb54a04e", null, "Admin", "ADMIN" },
                    { "f9b98c7c-cf55-415d-a049-a336b7c27a61", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPermissions_AspNetUsers_AdminId",
                table: "AdminPermissions",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPermissions_Permissions_PermissionId",
                table: "AdminPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Products_ProductId",
                table: "Cosmetics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorFeedbacks_Doctors_UserId",
                table: "DoctorFeedbacks",
                column: "UserId",
                principalTable: "Doctors",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorFeedbacks_Feedbacks_FeedbackId",
                table: "DoctorFeedbacks",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPrescriptions_AspNetUsers_UserId",
                table: "DoctorPrescriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPrescriptions_Prescriptions_PrescriptionId",
                table: "DoctorPrescriptions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_SenderId",
                table: "Feedbacks",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Products_ProductId",
                table: "Medicines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Pharmacies_PharmacyBranchId",
                table: "OrderItems",
                column: "PharmacyBranchId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_AspNetUsers_OwnerId",
                table: "Pharmacies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Locations_LocationId",
                table: "Pharmacies",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Pharmacies_ParentPharmacyId",
                table: "Pharmacies",
                column: "ParentPharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeePermissions_Permissions_PermissionId",
                table: "PharmacyEmployeePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeePermissions_PharmacyEmployees_EmployeeId",
                table: "PharmacyEmployeePermissions",
                column: "EmployeeId",
                principalTable: "PharmacyEmployees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployees_AspNetUsers_UserId",
                table: "PharmacyEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployees_Pharmacies_PharmacyId",
                table: "PharmacyEmployees",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyFeedbacks_Feedbacks_FeedbackId",
                table: "PharmacyFeedbacks",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyFeedbacks_Pharmacies_PharmacyId",
                table: "PharmacyFeedbacks",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_AdminUserId",
                table: "PharmacyRequest",
                column: "AdminUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_UserId",
                table: "PharmacyRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_Locations_LocationId",
                table: "PharmacyRequest",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientsId",
                table: "ProductIngredients",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "IngredientsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Products_ProductId",
                table: "ProductIngredients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId1",
                table: "ProductPharmacies",
                column: "BatchId1",
                principalTable: "Batches",
                principalColumn: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Pharmacies_PharmacyId",
                table: "ProductPharmacies",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Products_ProductId",
                table: "ProductPharmacies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescriptions_Prescriptions_PrescriptionId",
                table: "ProductPrescriptions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescriptions_Products_ProductId",
                table: "ProductPrescriptions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supports_AspNetUsers_UserId",
                table: "Supports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_AspNetUsers_UserId",
                table: "UserChats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "NotificationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrescriptions_AspNetUsers_UserId",
                table: "UserPrescriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrescriptions_Prescriptions_PrescriptionId",
                table: "UserPrescriptions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminPermissions_AspNetUsers_AdminId",
                table: "AdminPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminPermissions_Permissions_PermissionId",
                table: "AdminPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Products_ProductId",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorFeedbacks_Doctors_UserId",
                table: "DoctorFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorFeedbacks_Feedbacks_FeedbackId",
                table: "DoctorFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPrescriptions_AspNetUsers_UserId",
                table: "DoctorPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPrescriptions_Prescriptions_PrescriptionId",
                table: "DoctorPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_SenderId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Products_ProductId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Pharmacies_PharmacyBranchId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_OwnerId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Locations_LocationId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Pharmacies_ParentPharmacyId",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeePermissions_Permissions_PermissionId",
                table: "PharmacyEmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployeePermissions_PharmacyEmployees_EmployeeId",
                table: "PharmacyEmployeePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployees_AspNetUsers_UserId",
                table: "PharmacyEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyEmployees_Pharmacies_PharmacyId",
                table: "PharmacyEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyFeedbacks_Feedbacks_FeedbackId",
                table: "PharmacyFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyFeedbacks_Pharmacies_PharmacyId",
                table: "PharmacyFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_AdminUserId",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_UserId",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_PharmacyRequest_Locations_LocationId",
                table: "PharmacyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientsId",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_Products_ProductId",
                table: "ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchId1",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Pharmacies_PharmacyId",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPharmacies_Products_ProductId",
                table: "ProductPharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescriptions_Prescriptions_PrescriptionId",
                table: "ProductPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescriptions_Products_ProductId",
                table: "ProductPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Supports_AspNetUsers_UserId",
                table: "Supports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_AspNetUsers_UserId",
                table: "UserChats");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrescriptions_AspNetUsers_UserId",
                table: "UserPrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPrescriptions_Prescriptions_PrescriptionId",
                table: "UserPrescriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "288e5a5f-9c42-4cca-8621-5e4915d8018f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37649a5e-27a9-4136-9371-7cc045ed1f15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5887ffbb-44d4-45bb-a52e-459eb39709d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d1c4b89-3d85-4931-aa3f-7ca2e4cc54fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19d4518-7480-46ba-a872-106b11d12350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e3bf27-bcd1-4956-968a-6a06fb54a04e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b98c7c-cf55-415d-a049-a336b7c27a61");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPrescriptions",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "UserPrescriptions",
                newName: "PrescriptionID");

            migrationBuilder.RenameIndex(
                name: "IX_UserPrescriptions_UserId",
                table: "UserPrescriptions",
                newName: "IX_UserPrescriptions_UserID");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "UserNotifications",
                newName: "NotificationID");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                newName: "IX_UserNotifications_NotificationID");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotification_ReceiverId_NotificationId",
                table: "UserNotifications",
                newName: "IX_UserNotification_ReceiverId_NotificationID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserChats",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserChat_UserId_ChatId",
                table: "UserChats",
                newName: "IX_UserChat_UserID_ChatId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Supports",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SupportId",
                table: "Supports",
                newName: "SupportID");

            migrationBuilder.RenameIndex(
                name: "IX_Support_UserId",
                table: "Supports",
                newName: "IX_Support_UserID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SubCategories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "SubCategories",
                newName: "SubCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Products",
                newName: "SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                newName: "IX_Products_SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductPrescriptions",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "ProductPrescriptions",
                newName: "PrescriptionID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrescriptions_ProductId",
                table: "ProductPrescriptions",
                newName: "IX_ProductPrescriptions_ProductID");

            migrationBuilder.RenameColumn(
                name: "BatchId1",
                table: "ProductPharmacies",
                newName: "BatchID1");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "ProductPharmacies",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                table: "ProductPharmacies",
                newName: "PharmacyID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductPharmacies",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacy_ProductId_PharmacyId",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacy_ProductID_PharmacyID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_PharmacyId",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_PharmacyID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_BatchId1",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_BatchID1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPharmacies_BatchId",
                table: "ProductPharmacies",
                newName: "IX_ProductPharmacies_BatchID");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "ProductIngredients",
                newName: "IngredientsID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductIngredients",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredients_IngredientsId",
                table: "ProductIngredients",
                newName: "IX_ProductIngredients_IngredientsID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIngredient_ProductId_IngredientsId",
                table: "ProductIngredients",
                newName: "IX_ProductIngredient_ProductID_IngredientsID");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "Prescriptions",
                newName: "PrescriptionID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PharmacyRequest",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "PharmacyRequest",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "PharmacyRequest",
                newName: "LicenseID");

            migrationBuilder.RenameColumn(
                name: "AdminUserId",
                table: "PharmacyRequest",
                newName: "AdminUserID");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "PharmacyRequest",
                newName: "RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_UserId",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_LocationId",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyRequest_AdminUserId",
                table: "PharmacyRequest",
                newName: "IX_PharmacyRequest_AdminUserID");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                table: "PharmacyFeedbacks",
                newName: "PharmacyID");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "PharmacyFeedbacks",
                newName: "FeedbackID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyFeedback_PharmacyId",
                table: "PharmacyFeedbacks",
                newName: "IX_PharmacyFeedback_PharmacyID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PharmacyEmployees",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                table: "PharmacyEmployees",
                newName: "PharmacyID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "PharmacyEmployees",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployees_PharmacyId",
                table: "PharmacyEmployees",
                newName: "IX_PharmacyEmployees_PharmacyID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployee_UserId_PharmacyId",
                table: "PharmacyEmployees",
                newName: "IX_PharmacyEmployee_UserID_PharmacyID");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "PharmacyEmployeePermissions",
                newName: "PermissionID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "PharmacyEmployeePermissions",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployeePermissions_PermissionId",
                table: "PharmacyEmployeePermissions",
                newName: "IX_PharmacyEmployeePermissions_PermissionID");

            migrationBuilder.RenameIndex(
                name: "IX_PharmacyEmployeePermission_EmployeeId_PermissionId",
                table: "PharmacyEmployeePermissions",
                newName: "IX_PharmacyEmployeePermission_EmployeeID_PermissionID");

            migrationBuilder.RenameColumn(
                name: "ParentPharmacyId",
                table: "Pharmacies",
                newName: "ParentPharmacyID");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Pharmacies",
                newName: "OwnerID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Pharmacies",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "Pharmacies",
                newName: "LicenseID");

            migrationBuilder.RenameColumn(
                name: "PharmacyId",
                table: "Pharmacies",
                newName: "PharmacyID");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_ParentPharmacyId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_ParentPharmacyID");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_OwnerId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Pharmacies_LocationId",
                table: "Pharmacies",
                newName: "IX_Pharmacies_LocationID");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "PermissionID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Orders",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                newName: "IX_Orders_LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Order_UserID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "PharmacyBranchId",
                table: "OrderItems",
                newName: "PharmacyBranchID");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderItems",
                newName: "OrderItemID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_PharmacyBranchId",
                table: "OrderItems",
                newName: "IX_OrderItems_PharmacyBranchID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItem_OrderID_ProductID");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notifications",
                newName: "NotificationID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Medicines",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Locations",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "Ingredients",
                newName: "IngredientsID");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Feedbacks",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "Feedbacks",
                newName: "FeedbackID");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_SenderId",
                table: "Feedbacks",
                newName: "IX_Feedback_SenderID");

            migrationBuilder.RenameColumn(
                name: "LicenseId",
                table: "Doctors",
                newName: "LicenseID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Doctors",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctor_LicenseId",
                table: "Doctors",
                newName: "IX_Doctor_LicenseID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DoctorPrescriptions",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "DoctorPrescriptions",
                newName: "PrescriptionID");

            migrationBuilder.RenameIndex(
                name: "IX_DP_UsrId",
                table: "DoctorPrescriptions",
                newName: "IX_DP_UsrID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DoctorFeedbacks",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "DoctorFeedbacks",
                newName: "FeedbackID");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorFeedback_UserId",
                table: "DoctorFeedbacks",
                newName: "IX_DoctorFeedback_UserID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cosmetics",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "Batches",
                newName: "BatchID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AspNetUsers",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_User_LocationId",
                table: "AspNetUsers",
                newName: "IX_User_LocationID");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "AdminPermissions",
                newName: "PermissionID");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "AdminPermissions",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_AdminPermissions_PermissionId",
                table: "AdminPermissions",
                newName: "IX_AdminPermissions_PermissionID");

            migrationBuilder.AlterColumn<ulong>(
                name: "PharmacyID",
                table: "ProductPharmacies",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<ulong>(
                name: "ProductID",
                table: "ProductPharmacies",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "041ae8c2-6891-43b9-ad80-0a1fadc18bc5", null, "Admin", "ADMIN" },
                    { "34411420-9350-4a7d-92c0-8bf8723f2573", null, "SuperAdmin", "SUPERADMIN" },
                    { "614ab8c3-62b8-4c1b-825d-2f9dcae43e6d", null, "User", "USER" },
                    { "93f897e7-cd57-4013-b8e6-1af65ec463b0", null, "PharmacyManager", "PHARMACYMANAGER" },
                    { "b57a932d-f05a-41dd-be74-4f71686cadbb", null, "PharmacyEmployee", "PHARMACYEMPLOYEE" },
                    { "be08fa48-ed43-424c-9e7f-338699ad53e2", null, "Doctor", "DOCTOR" },
                    { "e3c6c020-0cf1-46ef-a083-a3142cced27b", null, "PharmacyOwner", "PHARMACYOWNER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPermissions_AspNetUsers_AdminID",
                table: "AdminPermissions",
                column: "AdminID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminPermissions_Permissions_PermissionID",
                table: "AdminPermissions",
                column: "PermissionID",
                principalTable: "Permissions",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationID",
                table: "AspNetUsers",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Products_ProductID",
                table: "Cosmetics",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorFeedbacks_Doctors_UserID",
                table: "DoctorFeedbacks",
                column: "UserID",
                principalTable: "Doctors",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorFeedbacks_Feedbacks_FeedbackID",
                table: "DoctorFeedbacks",
                column: "FeedbackID",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPrescriptions_AspNetUsers_UserID",
                table: "DoctorPrescriptions",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPrescriptions_Prescriptions_PrescriptionID",
                table: "DoctorPrescriptions",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserID",
                table: "Doctors",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_SenderID",
                table: "Feedbacks",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Products_ProductID",
                table: "Medicines",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Pharmacies_PharmacyBranchID",
                table: "OrderItems",
                column: "PharmacyBranchID",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductID",
                table: "OrderItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_LocationID",
                table: "Orders",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_AspNetUsers_OwnerID",
                table: "Pharmacies",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Locations_LocationID",
                table: "Pharmacies",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Pharmacies_ParentPharmacyID",
                table: "Pharmacies",
                column: "ParentPharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeePermissions_Permissions_PermissionID",
                table: "PharmacyEmployeePermissions",
                column: "PermissionID",
                principalTable: "Permissions",
                principalColumn: "PermissionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployeePermissions_PharmacyEmployees_EmployeeID",
                table: "PharmacyEmployeePermissions",
                column: "EmployeeID",
                principalTable: "PharmacyEmployees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployees_AspNetUsers_UserID",
                table: "PharmacyEmployees",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyEmployees_Pharmacies_PharmacyID",
                table: "PharmacyEmployees",
                column: "PharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyFeedbacks_Feedbacks_FeedbackID",
                table: "PharmacyFeedbacks",
                column: "FeedbackID",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyFeedbacks_Pharmacies_PharmacyID",
                table: "PharmacyFeedbacks",
                column: "PharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_AdminUserID",
                table: "PharmacyRequest",
                column: "AdminUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_AspNetUsers_UserID",
                table: "PharmacyRequest",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PharmacyRequest_Locations_LocationID",
                table: "PharmacyRequest",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Ingredients_IngredientsID",
                table: "ProductIngredients",
                column: "IngredientsID",
                principalTable: "Ingredients",
                principalColumn: "IngredientsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_Products_ProductID",
                table: "ProductIngredients",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchID",
                table: "ProductPharmacies",
                column: "BatchID",
                principalTable: "Batches",
                principalColumn: "BatchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Batches_BatchID1",
                table: "ProductPharmacies",
                column: "BatchID1",
                principalTable: "Batches",
                principalColumn: "BatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Pharmacies_PharmacyID",
                table: "ProductPharmacies",
                column: "PharmacyID",
                principalTable: "Pharmacies",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPharmacies_Products_ProductID",
                table: "ProductPharmacies",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescriptions_Prescriptions_PrescriptionID",
                table: "ProductPrescriptions",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescriptions_Products_ProductID",
                table: "ProductPrescriptions",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryID",
                table: "Products",
                column: "SubCategoryID",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryID",
                table: "SubCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supports_AspNetUsers_UserID",
                table: "Supports",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_AspNetUsers_UserID",
                table: "UserChats",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationID",
                table: "UserNotifications",
                column: "NotificationID",
                principalTable: "Notifications",
                principalColumn: "NotificationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrescriptions_AspNetUsers_UserID",
                table: "UserPrescriptions",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrescriptions_Prescriptions_PrescriptionID",
                table: "UserPrescriptions",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
