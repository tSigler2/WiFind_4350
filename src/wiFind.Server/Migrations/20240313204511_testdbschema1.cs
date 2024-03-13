using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class testdbschema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_Users_user_id",
                table: "SupportTickets");

            migrationBuilder.DropIndex(
                name: "IX_SupportTickets_user_id",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "SupportTickets");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "SupportTickets",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_username",
                table: "SupportTickets",
                column: "username");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets",
                column: "username",
                principalTable: "AccountInfos",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets");

            migrationBuilder.DropIndex(
                name: "IX_SupportTickets_username",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "username",
                table: "SupportTickets");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "SupportTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_user_id",
                table: "SupportTickets",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_Users_user_id",
                table: "SupportTickets",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
