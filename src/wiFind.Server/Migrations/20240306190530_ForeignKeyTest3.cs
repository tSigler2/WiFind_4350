using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_Users_owned_by",
                table: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Wifis_owned_by",
                table: "Wifis");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Wifis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_user_id",
                table: "Wifis",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_Users_user_id",
                table: "Wifis",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_Users_user_id",
                table: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Wifis_user_id",
                table: "Wifis");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Wifis");

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_owned_by",
                table: "Wifis",
                column: "owned_by");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_Users_owned_by",
                table: "Wifis",
                column: "owned_by",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
