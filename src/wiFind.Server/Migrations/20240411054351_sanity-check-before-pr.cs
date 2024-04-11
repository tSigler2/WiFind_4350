using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class sanitycheckbeforepr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "exp_date",
                table: "PaymentInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "0ecf686c-4065-4854-a77d-0f430a498867",
                column: "exp_date",
                value: "05/2025");

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "3aa3d1a3-00c6-4a9d-b75b-43ab61b4c5b1",
                column: "exp_date",
                value: "04/2030");

            migrationBuilder.UpdateData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "ba55b383-7ff8-44c4-b35c-3bb04b045c24",
                column: "exp_date",
                value: "04/2040");

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da",
                columns: new[] { "end_time", "start_time" },
                values: new object[] { new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7813), new DateTime(2024, 4, 2, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 1, 13, 50, 886, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488",
                column: "start_time",
                value: new DateTime(2024, 4, 9, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117",
                column: "start_time",
                value: new DateTime(2024, 4, 11, 0, 43, 50, 886, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f",
                column: "time_stamp",
                value: new DateTime(2024, 4, 1, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 9, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 11, 1, 43, 50, 886, DateTimeKind.Local).AddTicks(7767));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "exp_date",
                table: "PaymentInfos",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                column: "time_stamp",
                value: new DateTime(2024, 4, 1, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 9, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 11, 1, 15, 30, 457, DateTimeKind.Local).AddTicks(5885));

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
        }
    }
}
