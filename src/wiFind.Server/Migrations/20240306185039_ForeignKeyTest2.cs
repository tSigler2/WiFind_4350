using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserReferenceId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_Users_user_id",
                table: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Wifis_user_id",
                table: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserReferenceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Wifis");

            migrationBuilder.DropColumn(
                name: "UserReferenceId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserReferenceId",
                table: "Wifis",
                newName: "owned_by");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_Users_owned_by",
                table: "Wifis");

            migrationBuilder.DropIndex(
                name: "IX_Wifis_owned_by",
                table: "Wifis");

            migrationBuilder.RenameColumn(
                name: "owned_by",
                table: "Wifis",
                newName: "UserReferenceId");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Wifis",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "UserReferenceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_user_id",
                table: "Wifis",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserReferenceId",
                table: "Users",
                column: "UserReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserReferenceId",
                table: "Users",
                column: "UserReferenceId",
                principalTable: "Users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_Users_user_id",
                table: "Wifis",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id");
        }
    }
}
