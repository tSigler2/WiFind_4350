using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class sprint3dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    admin_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    permission_level = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dob = table.Column<DateOnly>(type: "date", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    amt_made = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "AdminAccountInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    admin_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccountInfos", x => x.username);
                    table.ForeignKey(
                        name: "FK_AdminAccountInfos_Admins_admin_id",
                        column: x => x.admin_id,
                        principalTable: "Admins",
                        principalColumn: "admin_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    feedback_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    rating = table.Column<short>(type: "smallint", nullable: false),
                    date_stamp = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    payInfo_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    payment_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name_on_card = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    card_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exp_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.payInfo_id);
                    table.ForeignKey(
                        name: "FK_PaymentInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountInfos", x => x.username);
                    table.ForeignKey(
                        name: "FK_UserAccountInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wifis",
                columns: table => new
                {
                    wifi_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    wifi_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    security = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    download_speed = table.Column<int>(type: "int", nullable: false),
                    upload_speed = table.Column<int>(type: "int", nullable: false),
                    wifi_latitude = table.Column<float>(type: "real", nullable: false),
                    wifi_longitude = table.Column<float>(type: "real", nullable: false),
                    radius = table.Column<float>(type: "real", nullable: false),
                    wifi_source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    owned_by = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    max_users = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifis", x => x.wifi_id);
                    table.ForeignKey(
                        name: "FK_Wifis_Users_owned_by",
                        column: x => x.owned_by,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportTickets",
                columns: table => new
                {
                    ticket_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    time_stamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    assigned_to = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Admins_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "Admins",
                        principalColumn: "admin_id");
                    table.ForeignKey(
                        name: "FK_SupportTickets_UserAccountInfos_username",
                        column: x => x.username,
                        principalTable: "UserAccountInfos",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    rent_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    wifi_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    locked_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    guest_password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.rent_id);
                    table.ForeignKey(
                        name: "FK_Rents_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_Rents_Wifis_wifi_id",
                        column: x => x.wifi_id,
                        principalTable: "Wifis",
                        principalColumn: "wifi_id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    request_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    wifi_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    time_stamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requested_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.request_id);
                    table.ForeignKey(
                        name: "FK_Requests_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Wifis_wifi_id",
                        column: x => x.wifi_id,
                        principalTable: "Wifis",
                        principalColumn: "wifi_id");
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    respnse_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    request_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    req_ans = table.Column<bool>(type: "bit", nullable: false),
                    guest_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.respnse_id);
                    table.ForeignKey(
                        name: "FK_Responses_Requests_request_id",
                        column: x => x.request_id,
                        principalTable: "Requests",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "amt_made", "dob", "first_name", "last_login", "last_name", "phone_number" },
                values: new object[,]
                {
                    { "06ed4db9-5799-4f39-85ba-3ac9c7f28729", 0.00m, new DateOnly(1, 1, 1), "user2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "222-222-2222" },
                    { "15ced7de-6cde-4d80-abc7-fb5d86179912", 0.00m, new DateOnly(1, 1, 1), "user1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "111-1111-1111" },
                    { "1c96d917-98fc-402e-855e-5ddf1e5276b6", 0.00m, new DateOnly(1, 1, 1), "user7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "777-777-7777" },
                    { "2a4aebdc-1a4f-47ee-b415-e4a6797f4231", 0.00m, new DateOnly(1, 1, 1), "user8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "888-888-8888" },
                    { "c1c35566-4fd3-4839-aa94-d8c85ccd4943", 0.00m, new DateOnly(1, 1, 1), "user3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "333-333-3333" },
                    { "cc7c133a-b731-4299-b310-770ba9f3fe9f", 0.00m, new DateOnly(1, 1, 1), "user9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "999-999-9999" },
                    { "ea2cef69-f132-402a-a162-e7d774388a64", 0.00m, new DateOnly(1, 1, 1), "user5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "555-555-5555" },
                    { "f4140a29-60b3-4e84-a8d6-0274432509a5", 0.00m, new DateOnly(1, 1, 1), "user10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "000-000-0000" },
                    { "f57d0e07-917a-47ea-86fc-eeee80ae5f13", 0.00m, new DateOnly(1, 1, 1), "user6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "666-666-6666" },
                    { "f69b8103-bf31-4cf0-a624-4f848de8a2eb", 0.00m, new DateOnly(1, 1, 1), "user4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tester", "444-444-4444" }
                });

            migrationBuilder.InsertData(
                table: "UserAccountInfos",
                columns: new[] { "username", "email", "passwordHash", "passwordSalt", "user_id" },
                values: new object[,]
                {
                    { "user1", "user1@example.com", new byte[] { 162, 133, 147, 207, 112, 222, 188, 104, 218, 237, 244, 242, 35, 48, 135, 171, 187, 69, 15, 80, 38, 225, 168, 7, 153, 25, 126, 0, 159, 98, 140, 197, 104, 140, 80, 22, 172, 195, 220, 36, 146, 221, 229, 0, 48, 90, 151, 194, 122, 149, 213, 165, 113, 128, 154, 233, 29, 159, 172, 77, 232, 163, 185, 178 }, new byte[] { 253, 13, 6, 121, 139, 183, 202, 45, 135, 246, 110, 174, 122, 199, 187, 173, 176, 37, 204, 132, 29, 230, 221, 39, 116, 108, 210, 96, 238, 165, 44, 88, 211, 13, 36, 149, 64, 246, 232, 102, 190, 155, 238, 166, 163, 208, 23, 39, 151, 109, 194, 95, 57, 225, 124, 128, 211, 208, 63, 7, 185, 219, 14, 198, 227, 239, 212, 182, 145, 158, 222, 81, 40, 165, 195, 107, 50, 46, 21, 102, 125, 5, 237, 158, 106, 204, 108, 163, 199, 40, 189, 78, 231, 175, 120, 120, 109, 209, 154, 110, 35, 50, 200, 20, 29, 102, 44, 144, 197, 130, 245, 132, 35, 140, 14, 194, 242, 0, 218, 230, 91, 201, 138, 133, 13, 23, 116, 22 }, "15ced7de-6cde-4d80-abc7-fb5d86179912" },
                    { "user10", "user10@example.com", new byte[] { 45, 242, 224, 113, 164, 125, 64, 205, 16, 138, 225, 251, 2, 184, 158, 34, 209, 61, 58, 237, 117, 120, 33, 60, 95, 36, 155, 135, 180, 202, 222, 239, 234, 224, 190, 137, 239, 45, 38, 167, 31, 158, 136, 17, 46, 176, 0, 185, 15, 225, 121, 8, 244, 222, 85, 224, 201, 70, 252, 14, 97, 203, 103, 213 }, new byte[] { 2, 64, 70, 157, 85, 103, 156, 13, 250, 171, 7, 208, 129, 96, 142, 187, 87, 183, 20, 58, 103, 27, 231, 97, 170, 215, 98, 224, 22, 168, 162, 16, 91, 165, 203, 145, 255, 11, 245, 120, 212, 135, 94, 199, 117, 94, 6, 161, 33, 185, 173, 234, 113, 43, 32, 252, 139, 129, 209, 162, 6, 195, 66, 181, 94, 58, 187, 17, 22, 82, 0, 60, 136, 54, 211, 108, 249, 201, 87, 69, 0, 189, 162, 112, 64, 5, 183, 196, 215, 146, 184, 49, 119, 182, 184, 23, 181, 66, 182, 180, 45, 115, 192, 70, 205, 160, 122, 178, 74, 103, 228, 196, 190, 13, 240, 52, 235, 12, 238, 160, 83, 155, 87, 98, 251, 59, 246, 37 }, "f4140a29-60b3-4e84-a8d6-0274432509a5" },
                    { "user2", "user2@example.com", new byte[] { 253, 15, 95, 190, 58, 179, 174, 225, 125, 125, 108, 162, 162, 180, 255, 149, 224, 50, 101, 236, 224, 123, 213, 228, 160, 10, 126, 14, 21, 133, 138, 120, 132, 70, 24, 82, 115, 211, 193, 200, 218, 225, 146, 148, 0, 250, 115, 91, 68, 123, 236, 120, 19, 151, 140, 95, 195, 113, 73, 28, 209, 156, 123, 111 }, new byte[] { 200, 134, 167, 51, 135, 11, 65, 0, 15, 237, 102, 12, 140, 203, 226, 37, 113, 94, 90, 193, 220, 51, 179, 115, 200, 37, 189, 235, 200, 193, 49, 216, 221, 250, 65, 6, 247, 107, 214, 191, 26, 17, 239, 47, 177, 140, 125, 255, 231, 216, 156, 32, 251, 82, 177, 167, 246, 234, 232, 237, 157, 215, 195, 89, 22, 210, 205, 220, 146, 163, 81, 57, 81, 253, 96, 121, 26, 12, 89, 109, 242, 93, 6, 205, 202, 61, 5, 239, 245, 1, 102, 233, 101, 106, 45, 61, 77, 248, 148, 68, 255, 1, 24, 135, 174, 219, 201, 210, 5, 112, 59, 233, 227, 80, 227, 171, 120, 3, 210, 254, 94, 55, 62, 67, 184, 69, 21, 103 }, "06ed4db9-5799-4f39-85ba-3ac9c7f28729" },
                    { "user3", "user3@example.com", new byte[] { 240, 231, 208, 38, 108, 24, 152, 113, 125, 119, 114, 219, 131, 102, 199, 113, 211, 165, 130, 254, 200, 105, 142, 225, 162, 252, 195, 142, 3, 39, 127, 140, 53, 127, 36, 191, 9, 40, 96, 107, 212, 188, 165, 150, 178, 232, 192, 42, 161, 191, 101, 58, 101, 248, 251, 59, 146, 172, 32, 28, 188, 62, 214, 249 }, new byte[] { 170, 7, 145, 230, 59, 118, 197, 251, 244, 31, 247, 13, 63, 231, 75, 214, 243, 37, 133, 128, 192, 73, 191, 198, 87, 92, 90, 36, 230, 91, 149, 186, 125, 84, 121, 86, 108, 20, 3, 122, 114, 60, 63, 5, 10, 231, 157, 197, 202, 244, 221, 96, 199, 119, 215, 34, 220, 17, 97, 129, 6, 219, 136, 35, 28, 136, 8, 252, 244, 53, 189, 39, 217, 114, 66, 103, 7, 80, 215, 78, 12, 60, 158, 230, 29, 28, 177, 74, 241, 8, 238, 190, 33, 1, 11, 206, 110, 227, 31, 122, 44, 59, 255, 143, 146, 151, 82, 160, 114, 97, 137, 143, 184, 208, 97, 128, 30, 93, 209, 241, 156, 151, 44, 143, 206, 113, 119, 40 }, "c1c35566-4fd3-4839-aa94-d8c85ccd4943" },
                    { "user4", "user4@example.com", new byte[] { 237, 128, 99, 177, 218, 69, 140, 197, 189, 156, 123, 132, 209, 135, 147, 181, 5, 255, 233, 28, 168, 241, 71, 190, 230, 51, 123, 209, 242, 228, 201, 196, 78, 222, 85, 199, 126, 197, 223, 231, 48, 217, 127, 47, 13, 141, 42, 225, 89, 20, 246, 146, 196, 47, 200, 224, 96, 164, 165, 170, 121, 19, 92, 100 }, new byte[] { 21, 131, 195, 236, 6, 138, 39, 231, 146, 80, 67, 225, 34, 251, 65, 119, 60, 12, 131, 246, 117, 135, 97, 84, 218, 193, 245, 92, 59, 161, 64, 141, 2, 192, 147, 52, 70, 181, 131, 189, 18, 204, 95, 164, 107, 225, 59, 84, 105, 212, 33, 166, 102, 9, 170, 242, 223, 151, 66, 139, 137, 206, 87, 143, 1, 230, 179, 167, 66, 21, 226, 102, 62, 38, 121, 197, 93, 211, 69, 205, 29, 64, 161, 232, 157, 148, 36, 7, 167, 201, 54, 7, 9, 53, 102, 90, 163, 220, 9, 80, 44, 86, 10, 95, 196, 217, 166, 247, 147, 106, 117, 4, 206, 249, 39, 85, 187, 192, 161, 199, 59, 224, 211, 21, 152, 204, 95, 175 }, "f69b8103-bf31-4cf0-a624-4f848de8a2eb" },
                    { "user5", "user5@example.com", new byte[] { 250, 41, 222, 138, 106, 225, 172, 175, 169, 209, 165, 106, 7, 43, 31, 195, 100, 13, 206, 7, 112, 1, 91, 219, 194, 212, 45, 41, 219, 244, 218, 241, 84, 120, 64, 193, 12, 40, 240, 187, 82, 170, 226, 8, 61, 146, 87, 215, 156, 100, 63, 235, 15, 231, 3, 237, 8, 226, 129, 36, 209, 213, 192, 183 }, new byte[] { 204, 107, 146, 4, 253, 100, 221, 96, 167, 92, 139, 43, 88, 131, 166, 21, 109, 78, 29, 246, 186, 119, 240, 158, 168, 232, 131, 249, 73, 195, 69, 105, 166, 57, 7, 61, 167, 130, 56, 69, 61, 246, 169, 132, 139, 117, 29, 247, 129, 174, 16, 185, 204, 221, 147, 90, 229, 220, 90, 134, 69, 95, 222, 64, 82, 251, 190, 55, 4, 49, 158, 112, 203, 27, 96, 22, 138, 144, 58, 61, 13, 167, 144, 132, 54, 101, 140, 251, 190, 119, 75, 212, 46, 115, 27, 88, 85, 162, 205, 9, 146, 9, 245, 88, 72, 222, 173, 66, 0, 115, 114, 139, 157, 3, 66, 210, 176, 210, 169, 196, 77, 237, 41, 20, 6, 132, 67, 120 }, "ea2cef69-f132-402a-a162-e7d774388a64" },
                    { "user6", "user6@example.com", new byte[] { 116, 203, 119, 59, 69, 123, 72, 253, 73, 164, 150, 72, 208, 176, 210, 0, 254, 154, 88, 40, 79, 227, 151, 35, 252, 24, 252, 90, 66, 179, 50, 54, 84, 85, 215, 20, 170, 154, 155, 95, 111, 90, 0, 140, 224, 72, 116, 110, 2, 108, 12, 70, 177, 56, 246, 144, 112, 10, 228, 180, 61, 135, 235, 47 }, new byte[] { 132, 198, 229, 224, 40, 212, 246, 28, 246, 15, 50, 8, 31, 62, 248, 123, 253, 89, 212, 4, 135, 21, 85, 208, 1, 252, 38, 14, 137, 39, 222, 252, 53, 136, 174, 123, 26, 27, 125, 187, 14, 171, 233, 106, 170, 196, 184, 89, 149, 178, 55, 26, 85, 88, 54, 125, 26, 15, 138, 57, 103, 147, 29, 20, 228, 222, 155, 17, 171, 163, 83, 181, 14, 23, 134, 76, 253, 2, 208, 208, 141, 40, 47, 190, 163, 65, 7, 105, 192, 213, 137, 26, 44, 127, 196, 2, 63, 175, 52, 73, 224, 102, 3, 89, 87, 109, 248, 77, 166, 105, 153, 195, 99, 214, 147, 249, 238, 83, 59, 221, 31, 142, 159, 250, 148, 162, 107, 176 }, "f57d0e07-917a-47ea-86fc-eeee80ae5f13" },
                    { "user7", "user7@example.com", new byte[] { 12, 227, 186, 212, 177, 65, 84, 239, 100, 97, 237, 5, 239, 118, 161, 115, 132, 7, 6, 247, 7, 255, 244, 236, 113, 144, 245, 22, 208, 204, 156, 68, 7, 182, 48, 109, 128, 2, 103, 178, 242, 48, 232, 220, 215, 252, 114, 79, 13, 118, 42, 253, 214, 105, 198, 55, 201, 240, 56, 77, 54, 19, 73, 24 }, new byte[] { 92, 144, 219, 144, 203, 168, 126, 209, 245, 87, 120, 188, 84, 192, 112, 117, 122, 26, 220, 102, 23, 167, 182, 174, 6, 78, 251, 190, 241, 182, 155, 106, 98, 46, 124, 245, 56, 158, 178, 236, 135, 115, 49, 54, 226, 206, 54, 8, 164, 67, 86, 160, 97, 129, 139, 238, 74, 23, 121, 14, 68, 25, 60, 219, 211, 81, 110, 99, 25, 205, 33, 87, 145, 181, 31, 223, 236, 34, 45, 134, 191, 223, 161, 101, 71, 184, 127, 68, 184, 16, 42, 49, 226, 58, 184, 211, 175, 60, 230, 63, 184, 135, 7, 135, 12, 9, 220, 11, 137, 138, 13, 101, 24, 38, 190, 131, 5, 125, 39, 156, 254, 48, 137, 85, 97, 24, 194, 252 }, "1c96d917-98fc-402e-855e-5ddf1e5276b6" },
                    { "user8", "user8@example.com", new byte[] { 201, 103, 194, 58, 162, 106, 211, 73, 23, 31, 18, 47, 166, 47, 175, 212, 0, 139, 233, 220, 14, 31, 221, 3, 127, 61, 20, 226, 12, 75, 33, 125, 201, 163, 249, 188, 50, 131, 28, 3, 112, 44, 162, 218, 161, 84, 161, 101, 174, 205, 232, 121, 9, 77, 30, 63, 172, 58, 29, 179, 12, 233, 146, 161 }, new byte[] { 81, 45, 190, 31, 186, 126, 66, 142, 15, 171, 46, 214, 86, 228, 81, 39, 254, 107, 39, 46, 164, 113, 19, 147, 54, 237, 140, 89, 116, 35, 156, 24, 101, 234, 60, 181, 219, 86, 149, 225, 36, 124, 57, 164, 59, 66, 131, 15, 36, 164, 161, 29, 23, 106, 96, 114, 241, 249, 8, 89, 55, 57, 140, 175, 72, 150, 45, 146, 63, 4, 137, 166, 90, 128, 86, 251, 175, 107, 164, 155, 62, 227, 37, 66, 135, 202, 177, 180, 8, 197, 172, 191, 24, 78, 123, 46, 89, 196, 21, 238, 217, 210, 251, 196, 33, 44, 221, 105, 215, 174, 128, 202, 174, 7, 132, 34, 202, 243, 22, 208, 152, 212, 207, 156, 207, 162, 43, 73 }, "2a4aebdc-1a4f-47ee-b415-e4a6797f4231" },
                    { "user9", "user9@example.com", new byte[] { 161, 97, 213, 112, 231, 203, 8, 179, 77, 29, 250, 210, 157, 178, 128, 197, 176, 72, 60, 74, 165, 189, 8, 140, 218, 25, 93, 37, 235, 96, 165, 142, 255, 230, 70, 98, 66, 118, 154, 209, 103, 97, 173, 42, 149, 131, 181, 203, 220, 253, 196, 165, 133, 148, 39, 137, 104, 120, 93, 130, 78, 221, 14, 143 }, new byte[] { 130, 1, 119, 239, 28, 147, 187, 168, 132, 30, 251, 1, 43, 116, 189, 200, 45, 85, 54, 117, 97, 244, 231, 243, 150, 48, 233, 58, 150, 35, 21, 64, 233, 237, 106, 110, 183, 218, 248, 98, 47, 26, 10, 82, 215, 146, 239, 253, 101, 12, 109, 127, 146, 144, 227, 17, 30, 154, 65, 20, 44, 155, 7, 59, 95, 206, 51, 208, 4, 211, 5, 218, 230, 239, 37, 81, 7, 124, 175, 126, 118, 20, 56, 126, 170, 107, 76, 82, 52, 137, 54, 35, 222, 163, 66, 91, 104, 97, 50, 179, 49, 134, 1, 198, 129, 85, 161, 123, 32, 203, 161, 115, 69, 40, 179, 61, 203, 19, 32, 56, 217, 243, 74, 16, 223, 102, 81, 238 }, "cc7c133a-b731-4299-b310-770ba9f3fe9f" }
                });

            migrationBuilder.InsertData(
                table: "Wifis",
                columns: new[] { "wifi_id", "download_speed", "max_users", "owned_by", "radius", "security", "upload_speed", "wifi_latitude", "wifi_longitude", "wifi_name", "wifi_source" },
                values: new object[,]
                {
                    { "1c243a97-b08d-4edb-b6e0-2fcadfe26c71", 100, 1, "c1c35566-4fd3-4839-aa94-d8c85ccd4943", 10f, "WPA3", 50, 100f, -100f, "Wifi_4", "Starlink" },
                    { "1d475c5a-f088-48fc-bb73-e83c5cbd364a", 300, 50, "15ced7de-6cde-4d80-abc7-fb5d86179912", 10f, "Unsecure", 300, 0f, 0f, "Wifi_1", "Fiber" },
                    { "34f3fb03-d917-48d2-8cd9-1e30c085cfb2", 300, 10, "15ced7de-6cde-4d80-abc7-fb5d86179912", 10f, "More Secure", 200, 0f, 0f, "Wifi_2", "Fiber" },
                    { "8f704d7a-7de0-4b03-8230-36cdcc6f21d0", 400, 100, "f4140a29-60b3-4e84-a8d6-0274432509a5", 10f, "Unsecured", 300, 10f, -5f, "Wifi_5", "Starlink" },
                    { "91720bff-b076-4b89-9a6e-36eebd68403f", 500, 1, "cc7c133a-b731-4299-b310-770ba9f3fe9f", 10f, "SurpriseMe", 500, 0f, 0f, "ItsWifi", "HotSpot" },
                    { "eca15f8b-ddfe-4109-bc9f-2e053e728c14", 450, 50, "c1c35566-4fd3-4839-aa94-d8c85ccd4943", 10f, "WPA2", 444, 10f, 10f, "Wifi_3", "ATT Fiber" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAccountInfos_admin_id",
                table: "AdminAccountInfos",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_user_id",
                table: "Feedbacks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentInfos_user_id",
                table: "PaymentInfos",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_user_id",
                table: "Rents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_wifi_id",
                table: "Rents",
                column: "wifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_user_id",
                table: "Requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_wifi_id",
                table: "Requests",
                column: "wifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_request_id",
                table: "Responses",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_assigned_to",
                table: "SupportTickets",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_username",
                table: "SupportTickets",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInfos_user_id",
                table: "UserAccountInfos",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_owned_by",
                table: "Wifis",
                column: "owned_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAccountInfos");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "PaymentInfos");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "SupportTickets");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "UserAccountInfos");

            migrationBuilder.DropTable(
                name: "Wifis");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
