using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ufn.Resiliencia.Api.Auth.WebApi.Migrations
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "99f325f5-c6bd-47aa-8dbb-da9c963259fc", "820389e4-844d-4624-8190-d8c3cf76be4d" });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "99f325f5-c6bd-47aa-8dbb-da9c963259fc");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "820389e4-844d-4624-8190-d8c3cf76be4d");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "d61f18ec-918d-49ec-9454-94b7d448ce79", "bb5fd36c-5dfb-4a8f-bb5b-e5425d1e895e", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "first_name", "is_blocked", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "c40f27a4-bd9a-4456-b2fc-0b2abcfdb971", 0, "00b9b1e0-6836-4d2d-8138-edfb8fa7f3b3", "teste@teste.com", true, "Cássio", false, "Gamarra", false, null, "TESTE@TESTE.COM", "TESTE@TESTE.COM", "AQAAAAEAACcQAAAAEHJI4fKP6QTGJjjYCvEg4x19h+h7pytjPZ2BRM463gScPi5rJsq8qzt9QDScyjZ6IA==", null, false, "18cbcfea-a9c9-44af-b1f7-c8b3d6b710a7", false, "teste@teste.com" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { "d61f18ec-918d-49ec-9454-94b7d448ce79", "c40f27a4-bd9a-4456-b2fc-0b2abcfdb971" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "role_id", "user_id" },
                keyValues: new object[] { "d61f18ec-918d-49ec-9454-94b7d448ce79", "c40f27a4-bd9a-4456-b2fc-0b2abcfdb971" });

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: "d61f18ec-918d-49ec-9454-94b7d448ce79");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "c40f27a4-bd9a-4456-b2fc-0b2abcfdb971");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[] { "99f325f5-c6bd-47aa-8dbb-da9c963259fc", "16e2690a-9cea-4745-bfdd-8434511cf147", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "first_name", "is_blocked", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[] { "820389e4-844d-4624-8190-d8c3cf76be4d", 0, "ec47fd06-61cb-49ba-a8b8-b23be2ee4985", "cassiogamarra@outlook.com", true, "Cássio", false, "Gamarra", false, null, "CASSIOGAMARRA@OUTLOOK.COM", "CASSIOGAMARRA@OUTLOOK.COM", "AQAAAAEAACcQAAAAELH+d/MtdXRZPO4vbNXp5n/1IoHVznSZ/9cAjWpnQiOow7m5xX7T5iAnK9bDmQbrOw==", null, false, "b264cea0-e869-4ce0-8a63-4704aa7230ed", false, "cassiogamarra@outlook.com" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[] { "99f325f5-c6bd-47aa-8dbb-da9c963259fc", "820389e4-844d-4624-8190-d8c3cf76be4d" });
        }
    }
}
