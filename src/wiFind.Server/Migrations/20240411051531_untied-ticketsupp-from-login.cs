using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class untiedticketsuppfromlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "SupportTickets",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "SupportTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "535079bc-8817-4f46-b6b3-f8216bf0852d",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 11));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "c7e66719-826b-49aa-9304-2637ae4311ba",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 11));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "dbda7ee1-d994-43a0-8080-1f41abfe4dee",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 11));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "0ecf686c-4065-4854-a77d-0f430a498867",
                column: "exp_date",
                value: new DateOnly(2025, 4, 11));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "3aa3d1a3-00c6-4a9d-b75b-43ab61b4c5b1",
                column: "exp_date",
                value: new DateOnly(2028, 4, 11));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "ba55b383-7ff8-44c4-b35c-3bb04b045c24",
                column: "exp_date",
                value: new DateOnly(2026, 4, 11));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da",
                columns: new[] { "end_time", "start_time" },
                values: new object[] { new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5829), new DateTime(2024, 4, 2, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5827) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 0, 45, 30, 457, DateTimeKind.Local).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488",
                column: "start_time",
                value: new DateTime(2024, 4, 9, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 0, 15, 30, 457, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f",
                columns: new[] { "email", "time_stamp", "username" },
                values: new object[] { "user1@example.com", new DateTime(2024, 4, 1, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5878), null });

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                columns: new[] { "email", "time_stamp", "username" },
                values: new object[] { "user6@example.com", new DateTime(2024, 4, 9, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5883), null });

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                columns: new[] { "email", "time_stamp", "username" },
                values: new object[] { "user3@example.com", new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5885), null });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.AddForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets",
                column: "username",
                principalTable: "AccountInfos",
                principalColumn: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportTickets_AccountInfos_username",
                table: "SupportTickets");

            migrationBuilder.DropColumn(
                name: "email",
                table: "SupportTickets");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "SupportTickets",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "535079bc-8817-4f46-b6b3-f8216bf0852d",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 9));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "c7e66719-826b-49aa-9304-2637ae4311ba",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 9));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "dbda7ee1-d994-43a0-8080-1f41abfe4dee",
                column: "date_stamp",
                value: new DateOnly(2024, 4, 9));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "0ecf686c-4065-4854-a77d-0f430a498867",
                column: "exp_date",
                value: new DateOnly(2025, 4, 9));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "3aa3d1a3-00c6-4a9d-b75b-43ab61b4c5b1",
                column: "exp_date",
                value: new DateOnly(2028, 4, 9));

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "ba55b383-7ff8-44c4-b35c-3bb04b045c24",
                column: "exp_date",
                value: new DateOnly(2026, 4, 9));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da",
                columns: new[] { "end_time", "start_time" },
                values: new object[] { new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 3, 31, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484",
                column: "start_time",
                value: new DateTime(2024, 4, 9, 16, 13, 15, 140, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
                column: "start_time",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117",
                column: "start_time",
                value: new DateTime(2024, 4, 9, 15, 43, 15, 140, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f",
                columns: new[] { "time_stamp", "username" },
                values: new object[] { new DateTime(2024, 3, 30, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5064), "user1" });

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                columns: new[] { "time_stamp", "username" },
                values: new object[] { new DateTime(2024, 4, 7, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5067), "user6" });

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                columns: new[] { "time_stamp", "username" },
                values: new object[] { new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(5069), "user3" });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 9, 16, 43, 15, 140, DateTimeKind.Local).AddTicks(4962));

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
