using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class guidstringtype : Migration
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
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "AccountInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    admin_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfos", x => x.username);
                    table.ForeignKey(
                        name: "FK_AccountInfos_Admins_admin_id",
                        column: x => x.admin_id,
                        principalTable: "Admins",
                        principalColumn: "admin_id");
                    table.ForeignKey(
                        name: "FK_AccountInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
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
                name: "Wifis",
                columns: table => new
                {
                    wifi_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    wifi_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    security = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                        name: "FK_SupportTickets_AccountInfos_username",
                        column: x => x.username,
                        principalTable: "AccountInfos",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Admins_assigned_to",
                        column: x => x.assigned_to,
                        principalTable: "Admins",
                        principalColumn: "admin_id");
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

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_admin_id",
                table: "AccountInfos",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_user_id",
                table: "AccountInfos",
                column: "user_id");

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
                name: "IX_Wifis_owned_by",
                table: "Wifis",
                column: "owned_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AccountInfos");

            migrationBuilder.DropTable(
                name: "Wifis");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
