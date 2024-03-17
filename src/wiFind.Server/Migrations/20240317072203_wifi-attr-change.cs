using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class wifiattrchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_Users_owned_by",
                table: "Wifis");

            migrationBuilder.AlterColumn<string>(
                name: "owned_by",
                table: "Wifis",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user3", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user1", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user1", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user10", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(801) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user9", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "user3", new DateTime(2024, 3, 17, 3, 22, 3, 44, DateTimeKind.Local).AddTicks(796) });

            migrationBuilder.AddForeignKey(
                name: "FK_Wifis_UserAccountInfos_owned_by",
                table: "Wifis",
                column: "owned_by",
                principalTable: "UserAccountInfos",
                principalColumn: "username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_UserAccountInfos_owned_by",
                table: "Wifis");

            migrationBuilder.AlterColumn<string>(
                name: "owned_by",
                table: "Wifis",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "c1c35566-4fd3-4839-aa94-d8c85ccd4943", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2286) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "15ced7de-6cde-4d80-abc7-fb5d86179912", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "15ced7de-6cde-4d80-abc7-fb5d86179912", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "f4140a29-60b3-4e84-a8d6-0274432509a5", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "cc7c133a-b731-4299-b310-770ba9f3fe9f", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                columns: new[] { "owned_by", "time_listed" },
                values: new object[] { "c1c35566-4fd3-4839-aa94-d8c85ccd4943", new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2283) });

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
