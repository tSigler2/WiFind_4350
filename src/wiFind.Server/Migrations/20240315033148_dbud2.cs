using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class dbud2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccountInfos_Admins_admin_id",
                table: "UserAccountInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserAccountInfos_admin_id",
                table: "UserAccountInfos");

            migrationBuilder.DropColumn(
                name: "admin_id",
                table: "UserAccountInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "admin_id",
                table: "UserAccountInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInfos_admin_id",
                table: "UserAccountInfos",
                column: "admin_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccountInfos_Admins_admin_id",
                table: "UserAccountInfos",
                column: "admin_id",
                principalTable: "Admins",
                principalColumn: "admin_id");
        }
    }
}
