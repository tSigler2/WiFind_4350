using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class morewifiattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "curr_rate",
                table: "Wifis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "time_listed",
                table: "Wifis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 20.99m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2286) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 2.0m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 5.0m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 10.0m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 0.50m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                columns: new[] { "curr_rate", "time_listed" },
                values: new object[] { 1.0m, new DateTime(2024, 3, 17, 2, 57, 15, 859, DateTimeKind.Local).AddTicks(2283) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "curr_rate",
                table: "Wifis");

            migrationBuilder.DropColumn(
                name: "time_listed",
                table: "Wifis");
        }
    }
}
