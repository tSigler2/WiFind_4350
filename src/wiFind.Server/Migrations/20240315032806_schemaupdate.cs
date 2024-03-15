using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class schemaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets");

            migrationBuilder.DropTable(
                name: "AccountInfos");

            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "passwordSalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "passwordSalt",
                table: "Admins");

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
                name: "UserAccountInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    admin_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountInfos", x => x.username);
                    table.ForeignKey(
                        name: "FK_UserAccountInfos_Admins_admin_id",
                        column: x => x.admin_id,
                        principalTable: "Admins",
                        principalColumn: "admin_id");
                    table.ForeignKey(
                        name: "FK_UserAccountInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAccountInfos_admin_id",
                table: "AdminAccountInfos",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInfos_admin_id",
                table: "UserAccountInfos",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInfos_user_id",
                table: "UserAccountInfos",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_UserAccountInfos_username",
                table: "SupportTickets",
                column: "username",
                principalTable: "UserAccountInfos",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_UserAccountInfos_username",
                table: "SupportTickets");

            migrationBuilder.DropTable(
                name: "AdminAccountInfos");

            migrationBuilder.DropTable(
                name: "UserAccountInfos");

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordHash",
                table: "Admins",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordSalt",
                table: "Admins",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "AccountInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    admin_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_admin_id",
                table: "AccountInfos",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_user_id",
                table: "AccountInfos",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets",
                column: "username",
                principalTable: "AccountInfos",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
