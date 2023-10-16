using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tachyon.Migrations
{
    public partial class Alert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "922eccc8-accd-4ead-8d64-18c3e4a9a4fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e81a1aad-f28e-4684-8686-e8e05f1e3e20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9699bbf-328b-499f-b0b0-98fc7fba245e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb15d32-5f37-4ce1-bc79-09a87e5d2815");

            migrationBuilder.CreateTable(
                name: "alerts",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntendedUser = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alerts", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_alerts_AspNetUsers_IntendedUser",
                        column: x => x.IntendedUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12b5e7f4-92f6-4b04-8714-9c5a7256c4bd", "b27f9faf-27ed-473d-b3a0-94a643fad357", "Doctor", "Doctor" },
                    { "7f2f288f-39ad-40b9-8fc3-b79e442f7d64", "35215181-de5b-440c-9511-2c3671fe243d", "Nurse", "NURSE" },
                    { "7ff77636-4c76-4da8-be19-ead2392e1689", "943e8daa-d0bc-47c9-8d80-6ba44ad8b430", "Patient", "PATIENT" },
                    { "e0c67455-5c96-4a78-a637-f7d8b2f81638", "e34a229f-0b86-4b33-ac91-31a8ac2eeea4", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alerts_IntendedUser",
                table: "alerts",
                column: "IntendedUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12b5e7f4-92f6-4b04-8714-9c5a7256c4bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f2f288f-39ad-40b9-8fc3-b79e442f7d64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ff77636-4c76-4da8-be19-ead2392e1689");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0c67455-5c96-4a78-a637-f7d8b2f81638");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "922eccc8-accd-4ead-8d64-18c3e4a9a4fa", "e2293668-c051-4244-892c-d278ff329180", "Doctor", "Doctor" },
                    { "e81a1aad-f28e-4684-8686-e8e05f1e3e20", "5cd1bcb2-530b-4780-85d6-bd7ff9b0a010", "Patient", "PATIENT" },
                    { "e9699bbf-328b-499f-b0b0-98fc7fba245e", "331b05c0-61b0-43a9-8944-f677aa4e0dc5", "Nurse", "NURSE" },
                    { "ebb15d32-5f37-4ce1-bc79-09a87e5d2815", "c8d53a16-03f2-4103-bf06-50dc6187ab18", "Admin", "ADMIN" }
                });
        }
    }
}
