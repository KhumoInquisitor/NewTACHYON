using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tachyon.Migrations
{
    public partial class khum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "692672ad-1b4f-4096-97e3-28458c07b473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab8b150-1a92-47ac-8324-8679fe355a1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77c49911-86c4-4799-a743-9b9e02e869be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2a55f6-573f-4da3-848c-097b0227945b");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patientID);
                });

            migrationBuilder.CreateTable(
                name: "Sappointments",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    patientID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sappointments", x => x.appointmentId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74d83695-b630-4b23-94e9-266886d3bb8b", "6b1b21e7-74fc-4088-93da-da8fecc4e25a", "Patient", "PATIENT" },
                    { "768b4a17-8a8c-4052-a017-ef3e9a736210", "73c0677e-c51d-4242-b859-f340d30bc7b7", "Nurse", "NURSE" },
                    { "8ae42942-ca99-4e84-af6a-b81558324fdd", "6ebe489f-96d3-43a6-a430-516b98e849c4", "Admin", "ADMIN" },
                    { "dee5d879-3f59-45b1-bc17-fbb33ccb7125", "86957253-b8b0-4534-8920-e1a9c700472c", "Doctor", "Doctor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Sappointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74d83695-b630-4b23-94e9-266886d3bb8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "768b4a17-8a8c-4052-a017-ef3e9a736210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ae42942-ca99-4e84-af6a-b81558324fdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee5d879-3f59-45b1-bc17-fbb33ccb7125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "692672ad-1b4f-4096-97e3-28458c07b473", "a20dd096-2fc0-4bf1-b7fd-8ed3ae279f79", "Patient", "PATIENT" },
                    { "6ab8b150-1a92-47ac-8324-8679fe355a1d", "1a919d69-7a07-44f9-a7f1-3cba17b488b5", "Admin", "ADMIN" },
                    { "77c49911-86c4-4799-a743-9b9e02e869be", "351be1c8-56ea-434d-a30e-b34bd5ffa9a2", "Nurse", "NURSE" },
                    { "8b2a55f6-573f-4da3-848c-097b0227945b", "04ce2e4c-94be-4114-8304-c29140babd74", "Doctor", "Doctor" }
                });
        }
    }
}
