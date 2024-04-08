using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class slightchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da",
                columns: new[] { "end_time", "start_time" },
                values: new object[] { new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1337), new DateTime(2024, 3, 29, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 20, 54, 51, 753, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488",
                column: "start_time",
                value: new DateTime(2024, 4, 5, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 20, 24, 51, 753, DateTimeKind.Local).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f",
                column: "time_stamp",
                value: new DateTime(2024, 3, 28, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 5, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                columns: new[] { "max_users", "time_listed" },
                values: new object[] { 5, new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                columns: new[] { "max_users", "time_listed" },
                values: new object[] { 10, new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1223) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 24, 51, 753, DateTimeKind.Local).AddTicks(1278));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da",
                columns: new[] { "end_time", "start_time" },
                values: new object[] { new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1978), new DateTime(2024, 3, 29, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1977) });

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 20, 53, 8, 174, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488",
                column: "start_time",
                value: new DateTime(2024, 4, 5, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117",
                column: "start_time",
                value: new DateTime(2024, 4, 7, 20, 23, 8, 174, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f",
                column: "time_stamp",
                value: new DateTime(2024, 3, 28, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 5, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d",
                column: "time_stamp",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                columns: new[] { "max_users", "time_listed" },
                values: new object[] { 1, new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                columns: new[] { "max_users", "time_listed" },
                values: new object[] { 1, new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1827) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1883));
        }
    }
}
