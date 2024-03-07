using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amtMade",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "fName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastLogin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "nickname",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "user_id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "dob",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserReferenceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "amt_made",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_login",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permission_level = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Wifis",
                columns: table => new
                {
                    wifi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wifi_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    security = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    wifi_latitude = table.Column<float>(type: "real", nullable: false),
                    wifi_longitude = table.Column<float>(type: "real", nullable: false),
                    wifi_source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserReferenceId = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifis", x => x.wifi_id);
                    table.ForeignKey(
                        name: "FK_Wifis_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserReferenceId",
                table: "Users",
                column: "UserReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_user_id",
                table: "Wifis",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserReferenceId",
                table: "Users",
                column: "UserReferenceId",
                principalTable: "Users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserReferenceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserReferenceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserReferenceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "amt_made",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "last_login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "dob",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "amtMade",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastLogin",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nickname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
