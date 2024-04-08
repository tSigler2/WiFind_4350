using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiFind.Server.Migrations
{
    /// <inheritdoc />
    public partial class moredummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountInfos",
                keyColumn: "username",
                keyValue: "user4");

            migrationBuilder.DeleteData(
                table: "AccountInfos",
                keyColumn: "username",
                keyValue: "user5");

            migrationBuilder.InsertData(
                table: "AccountInfos",
                columns: new[] { "username", "email", "last_login", "passwordHash", "passwordSalt", "user_id", "user_role" },
                values: new object[,]
                {
                    { "admin2", "admin2@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 250, 41, 222, 138, 106, 225, 172, 175, 169, 209, 165, 106, 7, 43, 31, 195, 100, 13, 206, 7, 112, 1, 91, 219, 194, 212, 45, 41, 219, 244, 218, 241, 84, 120, 64, 193, 12, 40, 240, 187, 82, 170, 226, 8, 61, 146, 87, 215, 156, 100, 63, 235, 15, 231, 3, 237, 8, 226, 129, 36, 209, 213, 192, 183 }, new byte[] { 204, 107, 146, 4, 253, 100, 221, 96, 167, 92, 139, 43, 88, 131, 166, 21, 109, 78, 29, 246, 186, 119, 240, 158, 168, 232, 131, 249, 73, 195, 69, 105, 166, 57, 7, 61, 167, 130, 56, 69, 61, 246, 169, 132, 139, 117, 29, 247, 129, 174, 16, 185, 204, 221, 147, 90, 229, 220, 90, 134, 69, 95, 222, 64, 82, 251, 190, 55, 4, 49, 158, 112, 203, 27, 96, 22, 138, 144, 58, 61, 13, 167, 144, 132, 54, 101, 140, 251, 190, 119, 75, 212, 46, 115, 27, 88, 85, 162, 205, 9, 146, 9, 245, 88, 72, 222, 173, 66, 0, 115, 114, 139, 157, 3, 66, 210, 176, 210, 169, 196, 77, 237, 41, 20, 6, 132, 67, 120 }, "ea2cef69-f132-402a-a162-e7d774388a64", 1 },
                    { "admin3", "admin3@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 237, 128, 99, 177, 218, 69, 140, 197, 189, 156, 123, 132, 209, 135, 147, 181, 5, 255, 233, 28, 168, 241, 71, 190, 230, 51, 123, 209, 242, 228, 201, 196, 78, 222, 85, 199, 126, 197, 223, 231, 48, 217, 127, 47, 13, 141, 42, 225, 89, 20, 246, 146, 196, 47, 200, 224, 96, 164, 165, 170, 121, 19, 92, 100 }, new byte[] { 21, 131, 195, 236, 6, 138, 39, 231, 146, 80, 67, 225, 34, 251, 65, 119, 60, 12, 131, 246, 117, 135, 97, 84, 218, 193, 245, 92, 59, 161, 64, 141, 2, 192, 147, 52, 70, 181, 131, 189, 18, 204, 95, 164, 107, 225, 59, 84, 105, 212, 33, 166, 102, 9, 170, 242, 223, 151, 66, 139, 137, 206, 87, 143, 1, 230, 179, 167, 66, 21, 226, 102, 62, 38, 121, 197, 93, 211, 69, 205, 29, 64, 161, 232, 157, 148, 36, 7, 167, 201, 54, 7, 9, 53, 102, 90, 163, 220, 9, 80, 44, 86, 10, 95, 196, 217, 166, 247, 147, 106, 117, 4, 206, 249, 39, 85, 187, 192, 161, 199, 59, 224, 211, 21, 152, 204, 95, 175 }, "f69b8103-bf31-4cf0-a624-4f848de8a2eb", 2 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "feedback_id", "date_stamp", "description", "rating", "subject", "user_id" },
                values: new object[,]
                {
                    { "535079bc-8817-4f46-b6b3-f8216bf0852d", new DateOnly(2024, 4, 7), "WiFind funds my fun in wifi.", (short)10, "Feedback 1", "1c96d917-98fc-402e-855e-5ddf1e5276b6" },
                    { "c7e66719-826b-49aa-9304-2637ae4311ba", new DateOnly(2024, 4, 7), "Useful. Try it.", (short)10, "My Genuine Unpaid Review", "2a4aebdc-1a4f-47ee-b415-e4a6797f4231" },
                    { "dbda7ee1-d994-43a0-8080-1f41abfe4dee", new DateOnly(2024, 4, 7), "Review bombing because I work here and need a raise.", (short)2, "Feedback 2", "c1c35566-4fd3-4839-aa94-d8c85ccd4943" }
                });

            migrationBuilder.InsertData(
                table: "PaymentInfos",
                columns: new[] { "payInfo_id", "card_number", "exp_date", "name_on_card", "payment_type", "user_id" },
                values: new object[,]
                {
                    { "0ecf686c-4065-4854-a77d-0f430a498867", "4523 5449 8586 0250", new DateOnly(2025, 4, 7), "GoodBye World", "Visa", "c1c35566-4fd3-4839-aa94-d8c85ccd4943" },
                    { "3aa3d1a3-00c6-4a9d-b75b-43ab61b4c5b1", "4523 5441 2487 5516", new DateOnly(2028, 4, 7), "Hello World", "Visa", "f4140a29-60b3-4e84-a8d6-0274432509a5" },
                    { "ba55b383-7ff8-44c4-b35c-3bb04b045c24", "5325 1730 0048 6151", new DateOnly(2026, 4, 7), "Hello World", "MasterCard", "f4140a29-60b3-4e84-a8d6-0274432509a5" }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "rent_id", "end_time", "guest_password", "locked_rate", "start_time", "user_id", "wifi_id" },
                values: new object[,]
                {
                    { "5601ce88-da39-4fa5-a5ba-573d53a8b4da", new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1978), "PassW0T", 100m, new DateTime(2024, 3, 29, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1977), "1c96d917-98fc-402e-855e-5ddf1e5276b6", "1d475c5a-f088-48fc-bb73-e83c5cbd364a" },
                    { "8a3c082c-d24e-4c40-842b-1b395ba32484", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "surprised?", 1.00m, new DateTime(2024, 4, 7, 20, 53, 8, 174, DateTimeKind.Local).AddTicks(1965), "f57d0e07-917a-47ea-86fc-eeee80ae5f13", "91720bff-b076-4b89-9a6e-36eebd68403f" },
                    { "a8d15a9c-55fd-418e-bb02-c8084fab15d4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc123", 0.50m, new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1962), "f57d0e07-917a-47ea-86fc-eeee80ae5f13", "8f704d7a-7de0-4b03-8230-36cdcc6f21d0" },
                    { "e0806ef7-7a42-48cb-9f31-d6538dfd3488", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0.10m, new DateTime(2024, 4, 5, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1973), "2a4aebdc-1a4f-47ee-b415-e4a6797f4231", "1c243a97-b08d-4edb-b6e0-2fcadfe26c71" },
                    { "e0f2ef9a-8f96-41d2-aafb-46115218a117", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "helloworld", 5.50m, new DateTime(2024, 4, 7, 20, 23, 8, 174, DateTimeKind.Local).AddTicks(1969), "2a4aebdc-1a4f-47ee-b415-e4a6797f4231", "8f704d7a-7de0-4b03-8230-36cdcc6f21d0" }
                });

            migrationBuilder.InsertData(
                table: "SupportTickets",
                columns: new[] { "ticket_id", "assigned_to", "description", "status", "subject", "time_stamp", "username" },
                values: new object[,]
                {
                    { "0fc8975c-c0c4-4236-a4fe-3c6e6265867f", null, "Please do something about it. ASAP. Or else I will never come here again!", 0, "Concerned that TikTok is stealing my Wifi", new DateTime(2024, 3, 28, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2030), "user1" },
                    { "daf29cbb-7867-4063-abe7-a0e57cc5813d", "06ed4db9-5799-4f39-85ba-3ac9c7f28729", "How do I contact the user renting out the StarLink wifi?", 1, "Contact with wifi renter", new DateTime(2024, 4, 5, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2033), "user6" },
                    { "f636b4db-07b5-4eaf-a9cc-685ea568b82d", "ea2cef69-f132-402a-a162-e7d774388a64", "i need step by step with powerpoint slides on how to get to my revenue.", 1, "need to see my profit", new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(2035), "user3" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: "f69b8103-bf31-4cf0-a624-4f848de8a2eb",
                column: "first_name",
                value: "admin3");

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1886));

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
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 21, 23, 8, 174, DateTimeKind.Local).AddTicks(1883));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountInfos",
                keyColumn: "username",
                keyValue: "admin2");

            migrationBuilder.DeleteData(
                table: "AccountInfos",
                keyColumn: "username",
                keyValue: "admin3");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "535079bc-8817-4f46-b6b3-f8216bf0852d");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "c7e66719-826b-49aa-9304-2637ae4311ba");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "feedback_id",
                keyValue: "dbda7ee1-d994-43a0-8080-1f41abfe4dee");

            migrationBuilder.DeleteData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "0ecf686c-4065-4854-a77d-0f430a498867");

            migrationBuilder.DeleteData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "3aa3d1a3-00c6-4a9d-b75b-43ab61b4c5b1");

            migrationBuilder.DeleteData(
                table: "PaymentInfos",
                keyColumn: "payInfo_id",
                keyValue: "ba55b383-7ff8-44c4-b35c-3bb04b045c24");

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "5601ce88-da39-4fa5-a5ba-573d53a8b4da");

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "8a3c082c-d24e-4c40-842b-1b395ba32484");

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "a8d15a9c-55fd-418e-bb02-c8084fab15d4");

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0806ef7-7a42-48cb-9f31-d6538dfd3488");

            migrationBuilder.DeleteData(
                table: "Rents",
                keyColumn: "rent_id",
                keyValue: "e0f2ef9a-8f96-41d2-aafb-46115218a117");

            migrationBuilder.DeleteData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "0fc8975c-c0c4-4236-a4fe-3c6e6265867f");

            migrationBuilder.DeleteData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "daf29cbb-7867-4063-abe7-a0e57cc5813d");

            migrationBuilder.DeleteData(
                table: "SupportTickets",
                keyColumn: "ticket_id",
                keyValue: "f636b4db-07b5-4eaf-a9cc-685ea568b82d");

            migrationBuilder.InsertData(
                table: "AccountInfos",
                columns: new[] { "username", "email", "last_login", "passwordHash", "passwordSalt", "user_id", "user_role" },
                values: new object[,]
                {
                    { "user4", "user4@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 237, 128, 99, 177, 218, 69, 140, 197, 189, 156, 123, 132, 209, 135, 147, 181, 5, 255, 233, 28, 168, 241, 71, 190, 230, 51, 123, 209, 242, 228, 201, 196, 78, 222, 85, 199, 126, 197, 223, 231, 48, 217, 127, 47, 13, 141, 42, 225, 89, 20, 246, 146, 196, 47, 200, 224, 96, 164, 165, 170, 121, 19, 92, 100 }, new byte[] { 21, 131, 195, 236, 6, 138, 39, 231, 146, 80, 67, 225, 34, 251, 65, 119, 60, 12, 131, 246, 117, 135, 97, 84, 218, 193, 245, 92, 59, 161, 64, 141, 2, 192, 147, 52, 70, 181, 131, 189, 18, 204, 95, 164, 107, 225, 59, 84, 105, 212, 33, 166, 102, 9, 170, 242, 223, 151, 66, 139, 137, 206, 87, 143, 1, 230, 179, 167, 66, 21, 226, 102, 62, 38, 121, 197, 93, 211, 69, 205, 29, 64, 161, 232, 157, 148, 36, 7, 167, 201, 54, 7, 9, 53, 102, 90, 163, 220, 9, 80, 44, 86, 10, 95, 196, 217, 166, 247, 147, 106, 117, 4, 206, 249, 39, 85, 187, 192, 161, 199, 59, 224, 211, 21, 152, 204, 95, 175 }, "f69b8103-bf31-4cf0-a624-4f848de8a2eb", 0 },
                    { "user5", "user5@example.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new byte[] { 250, 41, 222, 138, 106, 225, 172, 175, 169, 209, 165, 106, 7, 43, 31, 195, 100, 13, 206, 7, 112, 1, 91, 219, 194, 212, 45, 41, 219, 244, 218, 241, 84, 120, 64, 193, 12, 40, 240, 187, 82, 170, 226, 8, 61, 146, 87, 215, 156, 100, 63, 235, 15, 231, 3, 237, 8, 226, 129, 36, 209, 213, 192, 183 }, new byte[] { 204, 107, 146, 4, 253, 100, 221, 96, 167, 92, 139, 43, 88, 131, 166, 21, 109, 78, 29, 246, 186, 119, 240, 158, 168, 232, 131, 249, 73, 195, 69, 105, 166, 57, 7, 61, 167, 130, 56, 69, 61, 246, 169, 132, 139, 117, 29, 247, 129, 174, 16, 185, 204, 221, 147, 90, 229, 220, 90, 134, 69, 95, 222, 64, 82, 251, 190, 55, 4, 49, 158, 112, 203, 27, 96, 22, 138, 144, 58, 61, 13, 167, 144, 132, 54, 101, 140, 251, 190, 119, 75, 212, 46, 115, 27, 88, 85, 162, 205, 9, 146, 9, 245, 88, 72, 222, 173, 66, 0, 115, 114, 139, 157, 3, 66, 210, 176, 210, 169, 196, 77, 237, 41, 20, 6, 132, 67, 120 }, "ea2cef69-f132-402a-a162-e7d774388a64", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: "f69b8103-bf31-4cf0-a624-4f848de8a2eb",
                column: "first_name",
                value: "user4");

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "91720bff-b076-4b89-9a6e-36eebd68403f",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Wifis",
                keyColumn: "wifi_id",
                keyValue: "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                column: "time_listed",
                value: new DateTime(2024, 4, 7, 17, 27, 25, 925, DateTimeKind.Local).AddTicks(8255));
        }
    }
}
